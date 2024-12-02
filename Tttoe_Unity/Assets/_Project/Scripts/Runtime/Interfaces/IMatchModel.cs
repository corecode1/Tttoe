using System.Collections.Generic;

namespace com.tttoe.runtime.Interfaces
{
    public interface IMatchModel
    {
        public int MovesCount { get; }
        public GameModeType GameModeType { get; }
        public uint AllowedReverts { get; }
        public IReadOnlyList<MatchMove> Moves { get; }
        void RecordMove(BoardTilePosition position, TileOccupation prev, TileOccupation next);
        public MatchMove RevertLastMove();
        public void AddReverts(uint amount);
    }
}