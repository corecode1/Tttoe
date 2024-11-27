using com.tttoe.runtime;
using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public class NaiveAiMovesFinder : IMoveFinder
    {
        private IBoard _board;

        public NaiveAiMovesFinder(IBoard board)
        {
            _board = board;
        }

        public bool TryFindMove(out BoardTilePosition? move)
        {
            for (int rowIndex = 0; rowIndex < _board.Size; rowIndex++)
            {
                for (int colIndex = 0; colIndex < _board.Size; colIndex++)
                {
                    BoardTilePosition candidate = new(rowIndex, colIndex);
                    TileOccupation occupation = _board.GetTile(candidate);

                    if (occupation == TileOccupation.NonOccupied)
                    {
                        move = candidate;
                        return true;
                    }
                }
            }
            
            move = null;
            return false;
        }
    }
}