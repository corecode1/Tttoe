using System;
using System.ComponentModel;
using com.tttoe.runtime;
using Moq;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace com.tttoe.tests
{
    [TestFixture]
    public class BoardSolverTests : ZenjectUnitTestFixture
    {
        private char[,] _currentBoard;

        [SetUp]
        public void CommonInstall()
        {
            var board = GetMockBoard();
            Container.BindInstance(board.Object);
            Container.Bind<BoardSolver>().AsSingle();
        }

        private Mock<IBoard> GetMockBoard()
        {
            var board = new Mock<IBoard>();

            board.SetupGet(mock => mock.Size).Returns(() => _currentBoard.GetLength(0));
            board
                .Setup(mock => mock.GetTile(It.IsAny<BoardTilePosition>()))
                .Returns((BoardTilePosition position) =>
                    TileOccupation.FromChar(_currentBoard[position.Row, position.Column]));

            board
                .Setup(mock => mock.IsTileOccupied(It.IsAny<BoardTilePosition>()))
                .Returns((BoardTilePosition position) =>
                {
                    char symbol = _currentBoard[position.Row, position.Column];
                    return TileOccupation.FromChar(symbol) != TileOccupation.NonOccupied;
                });

            return board;
        }

        [Test]
        public void TestConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new BoardSolver(null));
        }

        [TestCaseSource(typeof(TestBoards), nameof(TestBoards.Boards))]
        public void TestBoardSolverReturnsExpectedResult(TestBoards.Board board)
        {
            _currentBoard = board.Matrix;
            var solver = Container.Resolve<BoardSolver>();
            var result = solver.CheckForGameOver(out _);

            Assert.AreEqual(board.ExpectedResult, result);
        }

        [TestCaseSource(typeof(TestBoards), nameof(TestBoards.Boards))]
        public void TestBoardSolverReturnsExpectedWinner(TestBoards.Board board)
        {
            _currentBoard = board.Matrix;
            var solver = Container.Resolve<BoardSolver>();
            solver.CheckForGameOver(out TileOccupation? winner);

            if (board.ExpectedWinner.HasValue)
            {
                Assert.AreEqual(TileOccupation.FromChar(board.ExpectedWinner.Value), winner);
            }
            else
            {
                Assert.Pass();
            }
        }
    }
}