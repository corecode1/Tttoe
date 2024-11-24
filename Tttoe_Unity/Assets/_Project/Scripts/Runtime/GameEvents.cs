using System;
using com.tttoe.runtime;

namespace com.tttoe.runtime
{
    public class GameEvents : IGameEvents
    {
        public event Action<BoardTilePosition> OnTileClicked;
        
        public void TriggerTileClicked(BoardTilePosition position) => OnTileClicked?.Invoke(position);
    }
}