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
            // TODO: Плохо, что Please() создает Mock<Player>, а не Player. 
            var playerMock = Create
                .Player()
                .WithHeadsCoin()
                .Please();
            var game = Create
                .Game()
                .PlayerWithCardsInProgress(playerMock, 1)
                .Please();

            game.NextRound();

            var cardsInProgress = game.FindCards(_ => _.Column.Type == ColumnType.InProgress);

            Assert.True(cardsInProgress[0].IsBlocked);
            // TODO: Тогда вам тут .Object бы не потребовался. 
            Assert.That(cardsInProgress[1].Player, Is.EqualTo(playerMock.Object));
            // TODO: Может еще стоит проверить, что новая карточка не заблокирована? А может подумать над удобным Assert DSL? 
        }
    }
}