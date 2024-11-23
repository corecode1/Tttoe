using com.tttoe.runtime;

namespace com.tttoe.tests
{
    public static class TestBoards
    {
        public struct Board
        {
            public char[,] Matrix;
            public GameOverCheckResult ExpectedResult;
            public char? ExpectedWinner;
        }

        public static Board[] Boards =
        {
            new Board()
            {
                Matrix = new[,]
                {
                    {'\n', '\n', '\n'},
                    {'\n', '\n', '\n'},
                    {'\n', '\n', '\n'}
                },
                ExpectedResult = GameOverCheckResult.None,
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'o', '\n', '\n'},
                    {'o', '\n', '\n'},
                    {'o', '\n', '\n'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'o'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'\n', 'x', '\n'},
                    {'\n', 'x', '\n'},
                    {'\n', 'x', '\n'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'x'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'\n', 'x', '\n'},
                    {'o', 'o', 'o'},
                    {'\n', 'x', '\n'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'o'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'\n', 'x', '\n'},
                    {'o', '\n', 'o'},
                    {'x', 'x', 'x'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'x'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'o', '\n', '\n'},
                    {'\n', 'o', '\n'},
                    {'\n', '\n', 'o'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'o'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'\n', '\n', 'x'},
                    {'\n', 'x', '\n'},
                    {'x', '\n', 'o'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'x'
            },
        };
    }
}