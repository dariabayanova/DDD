using Domain;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    // TODO: Аббревиатуры тоже пишутся в PascalCase: WhenInProgressColumnHasWip 
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

            // TODO: Ой, а зачем так сложно? У вас же Columns публичный, можно просто var cardsInProgress = game.Columns.InProgress;
            var cardsInProgress = game.FindCards(_ => _.Column.Type == ColumnType.InProgress);
            // TODO: Плохой ассерт. То, что их 2, еще не значит, что, например, они обе назначены на правильного игрока. Лучше сравнивать коллекции при помощи CollectionAssert
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