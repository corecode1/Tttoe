using System;
using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class MatchPresenter : IInitializable, IDisposable
    {
        private readonly IMatchView _view;
        private readonly IGameEvents _events;
        private readonly IConfig _config;
        private readonly IGameModeProvider _gameModeProvider;
        private readonly IFactory<GameModeType, IMatchModel> _modelFactory;

        private IMatchModel _model;
        private IGameMode _gameMode;

        private bool _isRevertInProgress;
        const int MovesPerRevert = 2;
        const int WaitDelayMs = 20;

        public MatchPresenter(
            IFactory<GameModeType, IMatchModel> modelFactory,
            IGameModeProvider gameModeProvider,
            IMatchView view,
            IGameEvents gameEvents,
            IConfig config)
        {
            _config = config;
            _gameModeProvider = gameModeProvider;
            _modelFactory = modelFactory;
            _view = view;
            _events = gameEvents;
        }

        public void Initialize()
        {
            _events.OnMatchStart += StartNewMatch;
            _events.OnMoveExecuted += HandleMoveExecuted;
            _view.OnRevertRequested += HandleRevertRequested;
            _view.Initialize();
        }

        public void Dispose()
        {
            _gameModeProvider.Dispose();
            _events.OnMatchStart -= StartNewMatch;
            _view.OnRevertRequested -= HandleRevertRequested;
            _view.Dispose();
        }

        private void StartNewMatch(GameModeType mode)
        {
            if (_model != null)
            {
                Debug.LogError($"Starting new match {mode} when previous {_model.GameModeType} is still running");
            }

            _model = _modelFactory.Create(mode);
            _gameMode = _gameModeProvider.Get(mode);
            _gameMode.OnPlayerChanged += HandlePlayerChanged;
            _view.Activate(true);
            _model.AddReverts(_config.InitialReverts);

            RunMatch();
        }

        private void HandlePlayerChanged(IPlayer player)
        {
            UpdateRevertAvailability();
        }

        private void HandleMoveExecuted(BoardTilePosition position, TileOccupation prev, TileOccupation next)
        {
            _model.RecordMove(position, prev, next);
        }

        private void HandleRevertRequested()
        {
            if (GetRevertAvailability() != RevertAvailability.Available)
            {
                return;
            }

            ExecuteRevert();
        }

        private async UniTask ExecuteRevert()
        {
            _isRevertInProgress = true;
            UpdateRevertAvailability();

            // since revert is possible during player move,
            // revert means cancelling 2 moves: opponent and user's
            for (int i = 0; i < MovesPerRevert; i++)
            {
                await UniTask.Delay(_config.RevertsDelayMs);
                MatchMove move = _model.RevertLastMove();
                _events.TriggerMoveRevert(move.Position, move.Previous, move.Next);
            }

            _isRevertInProgress = false;
            UpdateRevertAvailability();
        }

        private void UpdateRevertAvailability()
        {
            _view.SetRevertAvailability(GetRevertAvailability());
        }

        private async UniTask<TileOccupation> RunMatch()
        {
            await _gameMode.StartGame();

            GameOverCheckResult result = GameOverCheckResult.None;

            while (result == GameOverCheckResult.None)
            {
                await WaitForRevertEnd();
                result = await _gameMode.MakeTurn();
                _model.AddReverts(_config.RevertsPerTurn);
                UpdateRevertAvailability();
            }

            if (!_gameMode.TryGetWinner(out TileOccupation? winner) || !winner.HasValue)
            {
                throw new Exception("No winner after successful GameOverCheck");
            }

            EndMatch(result, winner);
            return winner.Value;
        }

        private async UniTask WaitForRevertEnd()
        {
            while (_isRevertInProgress)
            {
                await UniTask.Delay(WaitDelayMs);
            }
        }

        private void EndMatch(GameOverCheckResult result, TileOccupation? winner)
        {
            Debug.Log($"Game over! result: {result}, winner: {winner}");

            _gameMode.OnPlayerChanged -= HandlePlayerChanged;

            IMatchModel modelToDispatch = _model;
            _view.Activate(false);
            _model = null;
            _gameMode = null;
            _events.TriggerMatchEnd(modelToDispatch);
        }

        private RevertAvailability GetRevertAvailability()
        {
            // revert is only possible in user vs ai mode
            // and only during user move
            if (!(_gameMode is IUserVsAiGameMode))
            {
                return RevertAvailability.Unavailable;
            }
            
            if (_isRevertInProgress 
                || _model.MovesCount < MovesPerRevert 
                || _model.AllowedReverts == 0)
            {
                return RevertAvailability.Disabled;
            }

            return _gameMode.CurrentPlayer is IUserControlledPlayer
                ? RevertAvailability.Available
                : RevertAvailability.Disabled;
        }
    }
}