using System;
using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    // Implementation intended to work on any board size and symbols number 
    public class BoardSolver : ISolver
    {
        private readonly IBoard _board;

        private readonly TileOccupation[] _columnsOccupations;
        private bool _freeTilesExist;

        public int MinBoardSize => 3;

        public BoardSolver(IBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            if (board.Size < MinBoardSize)
            {
                throw new ArgumentOutOfRangeException(nameof(board.Size));
            }

            _board = board;
            _columnsOccupations = new TileOccupation[_board.Size];
        }

        public GameOverCheckResult CheckForGameOver(out TileOccupation? winner)
        {
            ResetSearch();
            winner = null;

            TileOccupation diagonal = TileOccupation.NonOccupied;
            TileOccupation counterDiagonal = TileOccupation.NonOccupied;

            for (int rowIndex = 0; rowIndex < _board.Size; rowIndex++)
            {
                TileOccupation row = TileOccupation.NonOccupied;

                for (int colIndex = 0; colIndex < _board.Size; colIndex++)
                {
                    TileOccupation current = _board.GetTile(new BoardTilePosition(rowIndex, colIndex));

                    TileOccupation col = _columnsOccupations[colIndex];
                    _columnsOccupations[colIndex] = ResolveLine(rowIndex == 0, col, current);
                    row = ResolveLine(colIndex == 0, row, current);
                    diagonal = ResolveMainDiagonal(diagonal, current, rowIndex, colIndex);
                    counterDiagonal = ResolveCounterDiagonal(counterDiagonal, current, rowIndex, colIndex);

                    if (current == TileOccupation.NonOccupied)
                    {
                        _freeTilesExist = true;
                    }
                }

                if (IsOccupied(row))
                {
                    winner = row;
                    return GameOverCheckResult.Win;
                }
            }

            if (CheckForDiagonalOrColsWin(ref winner, diagonal, counterDiagonal))
            {
                return GameOverCheckResult.Win;
            }

            return _freeTilesExist ? GameOverCheckResult.None : GameOverCheckResult.Tie;
        }

        private bool CheckForDiagonalOrColsWin(ref TileOccupation? winner, TileOccupation diagonal,
            TileOccupation counterDiagonal)
        {
            if (IsOccupied(diagonal))
            {
                winner = diagonal;
                return true;
            }

            if (IsOccupied(counterDiagonal))
            {
                winner = counterDiagonal;
                return true;
            }

            for (int col = 0; col < _columnsOccupations.Length; col++)
            {
                TileOccupation? colOccupation = _columnsOccupations[col];

                if (IsOccupied(colOccupation))
                {
                    winner = colOccupation;
                    return true;
                }
            }

            return false;
        }

        private bool IsOccupied(TileOccupation? occupation)
        {
            return occupation != null && occupation != TileOccupation.NonOccupied;
        }

        private void ResetSearch()
        {
            _freeTilesExist = false;

            for (var col = 0; col < _columnsOccupations.Length; col++)
            {
                _columnsOccupations[col] = TileOccupation.NonOccupied;
            }
        }

        private TileOccupation ResolveLine(bool isFirst, TileOccupation lineOccupation, TileOccupation current)
        {
            if (isFirst)
            {
                return current;
            }

            return lineOccupation == current ? lineOccupation : TileOccupation.NonOccupied;
        }

        private TileOccupation ResolveMainDiagonal(TileOccupation diagonalOccupation, TileOccupation current,
            int rowIndex, int colIndex)
        {
            bool isOnDiagonal = rowIndex == colIndex;
            bool isFirst = rowIndex == 0 && colIndex == 0;

            return ResolveDiagonal(diagonalOccupation, current, isOnDiagonal, isFirst);
        }

        private TileOccupation ResolveCounterDiagonal(TileOccupation diagonalOccupation, TileOccupation current,
            int rowIndex, int colIndex)
        {
            bool isOnDiagonal = rowIndex + colIndex == _board.Size - 1;
            bool isFirst = colIndex == _board.Size - 1 && rowIndex == 0;

            return ResolveDiagonal(diagonalOccupation, current, isOnDiagonal, isFirst);
        }

        private static TileOccupation ResolveDiagonal(TileOccupation diagonalOccupation, TileOccupation current,
            bool isOnDiagonal, bool isFirst)
        {
            if (!isOnDiagonal)
            {
                return diagonalOccupation;
            }

            if (isFirst)
            {
                return current;
            }

            return diagonalOccupation == current ? diagonalOccupation : TileOccupation.NonOccupied;
        }
    }
}