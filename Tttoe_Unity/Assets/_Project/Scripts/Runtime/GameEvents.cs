using System;
using com.tttoe.runtime;
using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public class GameEvents : IGameEvents
    {
        public event Action<BoardTilePosition> OnTileClicked;
        public event Action<BoardTilePosition, TileOccupation> OnMove;
        public event Action<GameModeType> OnMatchStart;
        public event Action<IMatchModel> OnMatchEnd;

        public void TriggerTileClicked(BoardTilePosition position) => OnTileClicked?.Invoke(position);

        public void TriggerMove(BoardTilePosition position, TileOccupation occupation) =>
            OnMove?.Invoke(position, occupation);

        public void TriggerMatchStart(GameModeType gameModeType) => OnMatchStart?.Invoke(gameModeType);
        public void TriggerMatchEnd(IMatchModel finishedMatch) => OnMatchEnd?.Invoke(finishedMatch);
    }
}