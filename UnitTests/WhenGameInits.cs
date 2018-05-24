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

        [Test]
        public void InProgressColumnHasNoCards()
        {
            var game = new Game();
            var inProgressCards = game.Columns.InProgress.Cards;

            Assert.AreEqual(0, inProgressCards.Count);
        }

        [Test]
        public void TestingColumnHasNoCards()
        {
        	var game = new Game();
            var testingCards = game.Columns.Testing.Cards;

            Assert.AreEqual(0, testingCards.Count);
        }
    }
}