using System;
using com.tttoe.runtime;
using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public interface IGameEvents
    {
        event Action<BoardTilePosition> OnTileClicked;
        event Action<BoardTilePosition, TileOccupation> OnMoveRequested;
        event Action<BoardTilePosition, TileOccupation, TileOccupation> OnMoveExecuted;
        event Action<BoardTilePosition, TileOccupation, TileOccupation> OnMoveRevert;
        event Action<GameModeType> OnMatchStart;
        event Action<IMatchModel> OnMatchEnd;
        event Action OnPlayAgain;

        void TriggerTileClicked(BoardTilePosition position);
        void TriggerMoveRequested(BoardTilePosition position, TileOccupation next);
        void TriggerMoveExecuted(BoardTilePosition position, TileOccupation prev, TileOccupation next);
        void TriggerMatchStart(GameModeType gameModeType);
        void TriggerMatchEnd(IMatchModel finishedMatch);
        void TriggerMoveRevert(BoardTilePosition position, TileOccupation prev, TileOccupation next);
        void TriggerPlayAgain();
    }
}