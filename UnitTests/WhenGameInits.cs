using Domain;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenGameInits
    {
        [Test]
        public void BacklogColumnHasNoCards()
        {
            var game = new Game();
            var backlogCards = game.Columns.Backlog.Cards;

            Assert.AreEqual(0, backlogCards.Count);
        }
    }
}