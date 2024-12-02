using System;
using com.tttoe.runtime;
using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public interface IGameEvents
    {
        event Action<BoardTilePosition> OnTileClicked;
        event Action<BoardTilePosition, TileOccupation> OnMove;
        event Action<GameModeType> OnMatchStart;
        event Action<IMatchModel> OnMatchEnd;

        void TriggerTileClicked(BoardTilePosition position);
        void TriggerMove(BoardTilePosition position, TileOccupation occupation);
        void TriggerMatchStart(GameModeType gameModeType);
        void TriggerMatchEnd(IMatchModel finishedMatch);
    }
}