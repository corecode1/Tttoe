using System;
using com.tttoe.runtime;

namespace com.tttoe.runtime
{
    public class GameEvents : IGameEvents
    {
        public event Action<BoardTilePosition> OnTileClicked;
        public event Action<BoardTilePosition, TileOccupation> OnMove;
        public event Action OnMatchStart;

        public void TriggerTileClicked(BoardTilePosition position) => OnTileClicked?.Invoke(position);

        public void TriggerMove(BoardTilePosition position, TileOccupation occupation) =>
            OnMove?.Invoke(position, occupation);

        public void TriggerMatchStart() => OnMatchStart?.Invoke();
    }
}