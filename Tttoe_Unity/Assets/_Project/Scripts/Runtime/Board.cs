using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public class Board
    {
        private TileOccupation[,] _tiles;

        public int Size { get; private set; }

        public Board(IConfig config)
        {
        }
        
        public void SetTile(BoardTilePosition position, TileOccupation occupation)
        {
            throw new System.NotImplementedException();
        }

        public TileOccupation GetTile(BoardTilePosition position)
        {
            throw new System.NotImplementedException();
        }

        public bool IsTileOccupied(BoardTilePosition position)
        {
            throw new System.NotImplementedException();
        }
    }
}