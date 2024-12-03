using System;
using Zenject;

namespace com.tttoe.runtime.Interfaces
{
    public interface IBoardView : IInitializable, IDisposable, IActivatable, IResetable
    {
        int Size { get; }
        event Action<BoardTilePosition> OnTileClicked;
        void UpdateTile(BoardTilePosition position, TileOccupation occupation);
    }
}