using System;
using com.tttoe.runtime;

namespace com.tttoe.runtime
{
    public interface IGameEvents
    {
        event Action<BoardTilePosition> OnTileClicked;
        event Action<BoardTilePosition, TileOccupation> OnMove;
        event Action OnMatchStart;

        void TriggerTileClicked(BoardTilePosition position);
        void TriggerMove(BoardTilePosition position, TileOccupation occupation);
        void TriggerMatchStart();
    }
}