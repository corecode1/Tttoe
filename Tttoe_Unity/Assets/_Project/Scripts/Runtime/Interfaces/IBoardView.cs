namespace com.tttoe.runtime.Interfaces
{
    public interface IBoardView
    {
        public int Size { get; }
        void UpdateTile(BoardTilePosition position, TileOccupation occupation);
    }
}