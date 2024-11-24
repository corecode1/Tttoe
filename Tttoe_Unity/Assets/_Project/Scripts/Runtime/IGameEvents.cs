using System;
using com.tttoe.runtime;

namespace com.tttoe.runtime
{
    public interface IGameEvents
    {
        event Action<BoardTilePosition> OnTileClicked;
        
        void TriggerTileClicked(BoardTilePosition position);
    }
}