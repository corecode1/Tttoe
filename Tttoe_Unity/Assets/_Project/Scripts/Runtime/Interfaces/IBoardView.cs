using System;

namespace com.tttoe.runtime.Interfaces
{
    public interface IBoardView
    {
        int Size { get; }
        event Action<BoardTilePosition> OnTileClicked;
        void UpdateTile(BoardTilePosition position, TileOccupation occupation);
    }
}