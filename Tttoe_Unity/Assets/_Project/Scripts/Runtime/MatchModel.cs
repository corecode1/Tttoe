using System.Collections.Generic;
using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public class MatchModel : IMatchModel
    {
        private readonly List<MatchMove> _moves;

        public uint AllowedReverts { get; private set; }
        public GameOverCheckResult Result { get; private set; }
        public TileOccupation? Winner { get; private set; }
        public int MovesCount => _moves.Count;
        public GameModeType GameModeType { get; }
        public IReadOnlyList<MatchMove> Moves => _moves;

        public MatchModel(GameModeType mode)
        {
            GameModeType = mode;
            _moves = new List<MatchMove>();
        }

        public void RecordMove(BoardTilePosition position, TileOccupation prev, TileOccupation next)
        {
            _moves.Add(new MatchMove(position, prev, next));
        }

        public MatchMove RevertLastMove()
        {
            AllowedReverts--;
            MatchMove lastMove = _moves[_moves.Count - 1];
            _moves.RemoveAt(_moves.Count - 1);
            return lastMove;
        }

        public void AddReverts(uint amount)
        {
            AllowedReverts += amount;
        }

        public void SetResult(GameOverCheckResult result, TileOccupation? winner)
        {
            Result = result;
            Winner = winner;
        }
    }
}