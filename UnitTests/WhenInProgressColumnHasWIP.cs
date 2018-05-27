using Domain;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenInProgressColumnHasWIP : BaseTest
    {
        [Test]
        public void PlayerCanGetNewCard()
        {
            var player = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = Create
                .Game()
                .WithWIPInProgress(2)
                .PlayerWithCardsInProgress(player, 1)
                .Please();

            game.NextRound();

            var cardsInProgress = game.FindCards(_ => _.Column.Type == ColumnType.InProgress);
            Assert.That(cardsInProgress.Count, Is.EqualTo(2));
        }

        [Test]
        public void PlayerCannotGetCardsMoreThanWIP()
        {
            var player = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = Create
                .Game()
                .WithWIPInProgress(2)
                .PlayerWithCardsInProgress(player, 2)
                .Please();

            game.NextRound();

            var cardsInProgress = game.FindCards(_ => _.Column.Type == ColumnType.InProgress);
            Assert.That(cardsInProgress.Count, Is.EqualTo(2));
        }
    }
}