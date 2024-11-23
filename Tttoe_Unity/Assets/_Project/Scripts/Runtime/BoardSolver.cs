namespace com.tttoe.runtime
{
    public class BoardSolver
    {
        private IBoard _board;

        public BoardSolver(IBoard board)
        {
            _board = board;
        }

        public GameOverCheckResult CheckForGameOver(out char? winner)
        {
            throw new System.NotImplementedException();
        }
    }
}