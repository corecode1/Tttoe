namespace com.tttoe.runtime
{
    public interface IBoard
    {
        int Size { get; }
        void SetTile(BoardTilePosition position, TileOccupation occupation);
        TileOccupation GetTile(BoardTilePosition position);
        bool IsTileOccupied(BoardTilePosition position);
    }
}