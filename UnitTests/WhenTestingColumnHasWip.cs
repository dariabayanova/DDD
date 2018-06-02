using Domain;
using NUnit.Framework;

namespace UnitTests
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
        public void PlayerCannotMoveCardsMoreThanWip()
        {
            var player = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = Create
                .Game()
                .WithWipInTesting(2)
                .PlayerWithCardsInProgress(player, 1)
                .PlayerWithCardsInTesting(player, 2)
                .Please();

            game.NextRound();

            var cardsInTesting = game.FindCards(_ => _.Column.Type == ColumnType.Testing);
            Assert.That(cardsInTesting.Count, Is.EqualTo(2));
        }
    }
}