using System;
using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public class Board : IBoard
    {
        private TileOccupation[,] _tiles;

        public int Size { get; private set; }

        public Board(IConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            Size = config.BoardSize;
            _tiles = new TileOccupation[Size, Size];
        }
        
        public void SetTile(BoardTilePosition position, TileOccupation occupation)
        {
            _tiles[position.Row, position.Column] = occupation;
        }

        public TileOccupation GetTile(BoardTilePosition position)
        {
            return _tiles[position.Row, position.Column];
        }

        public bool IsTileOccupied(BoardTilePosition position)
        {
            return _tiles[position.Row, position.Column] != TileOccupation.NonOccupied;
        }

        public void Reset()
        {
            Array.Clear(_tiles, 0, _tiles.Length);
        }
    }
}