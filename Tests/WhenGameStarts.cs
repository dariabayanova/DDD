using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WhenGameStarts
    {
        [Test]
        public void ToDoColumnHasNoCards()
        {
            var game = new Game();
            var todoCards = game.Columns.ToDo.Cards;

            Assert.AreEqual(0, todoCards.Count);
        }
    }
}