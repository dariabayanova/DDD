using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenPlayerFlipsCoinWithHeads : BaseTest
    {
        [Test]
        public void CardBlockedAndNewCardAssignedToPlayer()
        {
            var playerMock = Create
                .Player()
                .WithHeadsCoin()
                .Please();
            var game = Create
                .Game()
                .PlayerWithCardsInProgress(playerMock)
                .Please();

            game.NextRound();

            var firstCardInProgress = game.Columns.InProgress.Cards[0];
            var secondCardInProgress = game.Columns.InProgress.Cards[1];
            Assert.True(firstCardInProgress.IsBlocked);
            Assert.That(secondCardInProgress.Player, Is.EqualTo(playerMock.Object));
        }
    }
}