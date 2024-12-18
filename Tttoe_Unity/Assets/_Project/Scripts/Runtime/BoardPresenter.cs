using System;
using com.tttoe.runtime.Interfaces;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class BoardPresenter : IInitializable, IDisposable
    {
        private readonly IBoardView _view;
        private readonly IBoard _board;
        private readonly IGameEvents _events;
        private readonly IConfig _config;

        public BoardPresenter(IBoard board, IBoardView view, IGameEvents events, IConfig config)
        {
            _events = events;
            _board = board;
            _view = view;
            _config = config;

            if (_board.Size != view.Size)
            {
                Debug.LogError("Board size mismatch");
            }
        }

        public void Initialize()
        {
            _view.Initialize();
            _view.OnTileClicked += _events.TriggerTileClicked;
            _events.OnMoveRequested += SetTileOccupation;
            _events.OnMoveRevert += RevertMove;
            _events.OnMatchStart += HandleMatchStart;
            _events.OnMatchEnd += HandleMatchEnd;
            _events.OnPlayAgain += HandlePlayAgain;
        }

        public void Dispose()
        {
            _view.OnTileClicked -= _events.TriggerTileClicked;
            _events.OnMoveRequested -= SetTileOccupation;
            _events.OnMoveRevert -= RevertMove;
            _events.OnMatchStart -= HandleMatchStart;
            _events.OnPlayAgain -= HandlePlayAgain;
            _view.Dispose();
        }

        private void SetTileOccupation(BoardTilePosition position, TileOccupation next)
        {
            TileOccupation previousOccupation = _board.GetTile(position);
            _board.SetTile(position, next);
            _view.UpdateTile(position, next);
            _events.TriggerMoveExecuted(position, previousOccupation, next);
        }

        private void RevertMove(BoardTilePosition position, TileOccupation prev, TileOccupation next)
        {
            _board.SetTile(position, prev);
            _view.UpdateTile(position, prev);
        }

        private void HandleMatchStart(GameModeType type)
        {
            _view.Activate(true);
        }

        private void HandlePlayAgain()
        {
            _view.Activate(false);
            _view.Reset();
            _board.Reset();
        }

        private void HandleMatchEnd(IMatchModel _)
        {
            _view.Activate(_config.ShowBoardOnGameOver);
        }
    }
}