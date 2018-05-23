using Domain;
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

            var toDoCards = game.Columns.ToDo.Cards;
            Assert.That(toDoCards.Count, Is.GreaterThan(0));
        }
    }
}