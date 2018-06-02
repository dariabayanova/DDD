using System.Linq;
using Domain;
using NUnit.Framework;

namespace UnitTests.GameTests
{
    [TestFixture]
    public class WhenTestingColumnHasWip : BaseTest
    {
        [Test]
        public void PlayerCanMoveCardToTesting()
        {
            var player = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = Create
                .Game()
                .WithWipInTesting(2)
                .PlayerWithCardsInProgress(player, 1)
                .Please();

            game.NextRound();

            var playerCards = player.CurrentGame.FindCards(_ => _.Column.Type == ColumnType.Testing);
            var cardsWithPlayer =
                game.FindCards(_ => _.Column.Type == ColumnType.Testing && _.Player == player);
            CollectionAssert.AreEqual(playerCards, cardsWithPlayer);
        }

        [Test]
        public void FirstPlayerCannotMoveCardsMoreThanWip()
        {
            var firstPlayer = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var secondPlayer = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = Create
                .Game()
                .PlayerWithCardsInProgress(firstPlayer, 1)
                .PlayerWithCardsInTesting(secondPlayer, 2)
                .WithWipInTesting(2)
                .Please();

            game.NextRound();

            var firstPlayerCards = game.FindCards(_ => _.Player == firstPlayer).Single();
            Assert.That(firstPlayerCards.Column.Type, Is.EqualTo(ColumnType.InProgress));
        }
    }
}