using System.Linq;
using Domain;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenGameInits
    {
        [Test]
        public void ToDoColumnHasNoCards()
        {
            var game = new Game();
            var todoCards = game.Columns.ToDo.Cards;

            Assert.AreEqual(0, todoCards.Count);
        }

        [Test]
        public void AllColumnsHasNoCards()
        {
        	var game = new Game();
            var allCards = game.Columns.SelectMany(_ => _.Cards);

            Assert.AreEqual(0, allCards.Count());

        }
    }
}