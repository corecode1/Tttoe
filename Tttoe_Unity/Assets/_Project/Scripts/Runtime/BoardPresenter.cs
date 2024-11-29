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

        public BoardPresenter(IBoard board, IBoardView view, IGameEvents events)
        {
            _events = events;
            _board = board;
            _view = view;

            if (_board.Size != view.Size)
            {
                Debug.LogError("Board size mismatch");
            }
        }

        public void SetTileOccupation(BoardTilePosition position, TileOccupation occupation)
        {
            _board.SetTile(position, occupation);
            _view.UpdateTile(position, occupation);
        }

        public void Initialize()
        {
            _view.Initialize();
            _view.OnTileClicked += _events.TriggerTileClicked;
            _events.OnMove += SetTileOccupation;
            _events.OnMatchStart += HandleMatchStart;
        }

        public void Dispose()
        {
            _view.OnTileClicked -= _events.TriggerTileClicked;
            _events.OnMove -= SetTileOccupation;
            _events.OnMatchStart -= HandleMatchStart;
            _view.Dispose();
        }

        private void HandleMatchStart()
        {
            _view.Activate(true);
        }
    }
}