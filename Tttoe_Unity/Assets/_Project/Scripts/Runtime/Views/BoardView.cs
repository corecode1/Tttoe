using System;
using com.tttoe.runtime.Interfaces;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class BoardView : UiPanel, IBoardView
    {
        [SerializeField] private TileView[] _tiles;
        [field: SerializeField] public int Size { get; private set; } = 3;

        public event Action<BoardTilePosition> OnTileClicked;

        public override void Initialize()
        {
            base.Initialize();

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    // Tiles are expected to be placed in correct order
                    // so no need to set child indexes manually
                    BoardTilePosition position = new(row, col);
                    TileView tile = GetTile(position);
                    tile.Init(position);
                    tile.OnClicked += HandleTileClicked;
                }
            }
        }
        
        public override void Dispose()
        {
            foreach (TileView tile in _tiles)
            {
                tile.OnClicked -= HandleTileClicked;
            }
        }

        private void HandleTileClicked(BoardTilePosition position)
        {
            OnTileClicked?.Invoke(position);
        }

        public void UpdateTile(BoardTilePosition position, TileOccupation occupation)
        {
            GetTile(position).SetState(occupation);
        }

        private TileView GetTile(BoardTilePosition position)
        {
            return _tiles[position.ToSingleDimensionIndex(Size)];
        }
    }
}