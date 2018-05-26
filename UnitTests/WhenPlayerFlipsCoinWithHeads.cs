using Domain;
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

            var cardsInProgress = game.FindCards(_ => _.Column.Type == ColumnType.InProgress);

            Assert.True(cardsInProgress[0].IsBlocked);
            Assert.That(cardsInProgress[1].Player, Is.EqualTo(playerMock.Object));
        }
    }
}