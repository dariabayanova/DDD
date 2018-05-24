using Domain;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenGameStarts
    {
        [Test]
        public void GameHasCardsInToDoColumn()
        {
        	var game = new Game();

            game.Start();

            var toDoCards = game.Columns.Backlog.Cards;
            Assert.That(toDoCards.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GameGenerates10Cards()
        {
            var gameMock = new Mock<Game>();
            gameMock.Setup(_ => _.GenerateCards(10));

            gameMock.Object.Start();

            gameMock.Verify(_ => _.GenerateCards(10), Times.Exactly(1));
        }
    }
}