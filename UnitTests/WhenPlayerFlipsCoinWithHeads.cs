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
            var player = Create
                .Player()
                .WithHeadsCoin()
                .Please();
            var game = Create
                .Game()
                .PlayerWithCardsInProgress(player, 1)
                .Please();

            game.NextRound();

            var cardsInProgress = game.FindCards(_ => _.Column.Type == ColumnType.InProgress);

            Assert.True(cardsInProgress[0].IsBlocked);
            Assert.That(cardsInProgress[1].Player, Is.EqualTo(player));
            // TODO: Может еще стоит проверить, что новая карточка не заблокирована? А может подумать над удобным Assert DSL? 
        }
    }
}