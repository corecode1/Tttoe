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
                    {'\0', '\0', '\0'},
                    {'\0', '\0', '\0'},
                    {'\0', '\0', '\0'}
                },
                ExpectedResult = GameOverCheckResult.None,
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'o', '\0', '\0'},
                    {'o', '\0', '\0'},
                    {'o', '\0', '\0'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'o'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'\0', 'x', '\0'},
                    {'\0', 'x', '\0'},
                    {'\0', 'x', '\0'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'x'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'\0', 'x', '\0'},
                    {'o', 'o', 'o'},
                    {'\0', 'x', '\0'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'o'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'\0', 'x', '\0'},
                    {'o', '\0', 'o'},
                    {'x', 'x', 'x'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'x'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'\0', '\0', '\0'},
                    {'\0', '\0', '\0'},
                    {'\0', '\0', 'o'}
                },
                ExpectedResult = GameOverCheckResult.None,
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'o', '\0', '\0'},
                    {'\0', 'o', '\0'},
                    {'\0', '\0', 'o'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'o'
            },
            new Board()
            {
                Matrix = new[,]
                {
                    {'\0', '\0', 'x'},
                    {'\0', 'x', '\0'},
                    {'x', '\0', 'o'}
                },
                ExpectedResult = GameOverCheckResult.Win,
                ExpectedWinner = 'x'
            },
        };
    }
}