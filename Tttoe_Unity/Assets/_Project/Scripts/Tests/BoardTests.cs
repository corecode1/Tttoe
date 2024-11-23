using System;
using com.tttoe.runtime;
using com.tttoe.runtime.Interfaces;
using Moq;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace com.tttoe.tests
{
    [TestFixture]
    public class BoardTests : ZenjectUnitTestFixture
    {
        private const int TestBoardSize = 3;
        private readonly BoardTilePosition _testBoardPosition = new(1, 1);

        [SetUp]
        public void CommonInstall()
        {
            var config = new Mock<IConfig>();
            config.SetupGet(mock => mock.BoardSize).Returns(TestBoardSize);
            Container.BindInstance(config.Object);
            Container.Bind<Board>().AsSingle();
        }

        [Test]
        public void TestConstructorThrowsIfNullConfig()
        {
            Assert.Throws<ArgumentNullException>(() => new Board(null));
        }

        [Test]
        public void TestDefaultTileOccupation()
        {
            var board = Container.Resolve<Board>();
            Assert.AreEqual(board.IsTileOccupied(default), TileOccupation.NonOccupied);
        }

        [Test]
        public void TestDefaultIsTileOccupied()
        {
            var board = Container.Resolve<Board>();
            Assert.IsFalse(board.IsTileOccupied(default));
        }
        
        [Test]
        public void TestIsTileOccupiedReturnsTrue()
        {
            var board = Container.Resolve<Board>();
            var expectedOccupation = TileOccupation.Player1;
            board.SetTile(_testBoardPosition, expectedOccupation);
            Assert.IsTrue(board.IsTileOccupied(default));
        }
        
        [Test]
        public void TestSetGetTileOccupation()
        {
            var board = Container.Resolve<Board>();
            var expectedOccupation = TileOccupation.Player1;
            board.SetTile(_testBoardPosition, expectedOccupation);
            Assert.AreEqual(board.GetTile(_testBoardPosition), expectedOccupation);
        }
    }
}