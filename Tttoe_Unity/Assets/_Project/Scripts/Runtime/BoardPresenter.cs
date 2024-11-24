using com.tttoe.runtime.Interfaces;
using ModestTree;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class BoardPresenter : IInitializable
    {
        private IBoardView _view;
        private IBoard _board;

        public BoardPresenter(IBoard board, IBoardView view)
        {
            _board = board;
            _view = view;

            if (_board.Size != view.Size)
            {
                Debug.LogError("Board size mismatch");
            }
        }

        public void Initialize()
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    SetTile(new BoardTilePosition(row, col), TileOccupation.NonOccupied);
                }
            }
        }

        public void SetTile(BoardTilePosition position, TileOccupation occupation)
        {
            _board.SetTile(position, occupation);
            _view.UpdateTile(position, occupation);
        }
    }
}