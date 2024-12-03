using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public interface IBoard : IResetable
    {
        int Size { get; }
        void SetTile(BoardTilePosition position, TileOccupation occupation);
        TileOccupation GetTile(BoardTilePosition position);
        bool IsTileOccupied(BoardTilePosition position);
    }
}