using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenPlayerFlipsCoinWithHeads : BaseTest
    {
        [Test]
        public void CardBlockedAndNewCardAssignedToPlayer()
        {
            var player = Create
                .Player()
                .WithHeadsCoin()
                .Please();
            var game = Create
                .Game()
                .PlayerWithCardsInProgress(player, 1)
                .Please();

            game.NextRound();

            var cardsInProgress = game.Columns.InProgress.Cards;

            Assert.True(cardsInProgress[0].IsBlocked);
            Assert.That(cardsInProgress[1].Player, Is.EqualTo(player));
            Assert.False(cardsInProgress[1].IsBlocked);
            // TODO: А может подумать над удобным Assert DSL?
        }
    }
}