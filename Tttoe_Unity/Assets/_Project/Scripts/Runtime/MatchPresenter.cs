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
        private readonly IFactory<GameModeType, IMatchModel> _modelFactory;
        private readonly IGameModeProvider _gameModeProvider;

        private IMatchModel _model;
        private IGameMode _gameMode;


        public MatchPresenter(
            IFactory<GameModeType, IMatchModel> modelFactory,
            IGameModeProvider gameModeProvider,
            IMatchView view,
            IGameEvents gameEvents)
        {
            _gameModeProvider = gameModeProvider;
            _modelFactory = modelFactory;
            _view = view;
            _events = gameEvents;
        }

        public void Initialize()
        {
            _events.OnMatchStart += StartNewMatch;
        }

        public void Dispose()
        {
            _gameModeProvider.Dispose();
            _events.OnMatchStart -= StartNewMatch;
        }

        private void StartNewMatch(GameModeType mode)
        {
            if (_model != null)
            {
                Debug.LogError($"Starting new match {mode} when previous {_model.GameModeType} is still running");
            }

            _model = _modelFactory.Create(mode);
            _gameMode = _gameModeProvider.Get(mode);
            RunMatch();
        }

        private async UniTask<TileOccupation> RunMatch()
        {
            await _gameMode.StartGame();

            GameOverCheckResult result = GameOverCheckResult.None;

            while (result == GameOverCheckResult.None)
            {
                result = await _gameMode.MakeTurn();
            }

            if (!_gameMode.TryGetWinner(out TileOccupation? winner) || !winner.HasValue)
            {
                throw new Exception("No winner after successful GameOverCheck");
            }

            Debug.Log($"Game over! result: {result}, winner: {winner}");

            _events.TriggerMatchEnd(_model);
            _model = null;
            _gameMode = null;
            return winner.Value;
        }
    }
}