using System;
using com.tttoe.runtime;
using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public class GameEvents : IGameEvents
    {
        public event Action<BoardTilePosition> OnTileClicked;
        public event Action<BoardTilePosition, TileOccupation> OnMoveRequested;
        public event Action<BoardTilePosition, TileOccupation, TileOccupation> OnMoveExecuted;
        public event Action<BoardTilePosition, TileOccupation, TileOccupation> OnMoveRevert;
        public event Action<GameModeType> OnMatchStart;
        public event Action<IMatchModel> OnMatchEnd;
        public event Action OnPlayAgain;

        public void TriggerTileClicked(BoardTilePosition position) => OnTileClicked?.Invoke(position);

        public void TriggerMoveRequested(BoardTilePosition position, TileOccupation prev) =>
            OnMoveRequested?.Invoke(position, prev);
        
        public void TriggerMoveExecuted(BoardTilePosition position, TileOccupation prev, TileOccupation next) =>
            OnMoveExecuted?.Invoke(position, prev, next);

        public void TriggerMatchStart(GameModeType gameModeType) => OnMatchStart?.Invoke(gameModeType);
        public void TriggerMatchEnd(IMatchModel finishedMatch) => OnMatchEnd?.Invoke(finishedMatch);

        public void TriggerMoveRevert(BoardTilePosition position, TileOccupation prev, TileOccupation next)
        {
            OnMoveRevert?.Invoke(position, prev, next);
        }

        public void TriggerPlayAgain() => OnPlayAgain?.Invoke();
    }
}