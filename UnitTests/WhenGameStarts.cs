using System.Collections.Generic;
using Domain;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenGameStarts
    {
        [Test]
        public void GameGenerates10Cards()
        {
            var gameMock = new Mock<Game>();
            gameMock.Setup(_ => _.GenerateCards(10));

            gameMock.Object.Start(Create3Players());

            gameMock.Verify(_ => _.GenerateCards(10), Times.Once);
        }

        [Test]
        public void GameHas3Players()
        {
        	var game = new Game();

            game.Start(Create3Players());

            Assert.That(game.Players.Count, Is.EqualTo(3));
        }

        private static List<Player> Create3Players()
        {
            return new List<Player>{new Player(), new Player(), new Player()};
        }
    }
}