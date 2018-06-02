using System.Collections.Generic;
using System.Linq;
using Domain;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenPlayerFlipsCoinWithTails : BaseTest
    {
        [Test]
        public void NewCardAssignedToPlayer()
        {
            var player = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = new Game();
            game.Start();
            game.Join(player);

            game.NextRound();

            var oneCardInProgress = game.Columns.InProgress.Cards.Single();
            Assert.That(oneCardInProgress.Player, Is.EqualTo(player));
        }

        [Test]
        public void BlockedCardInProgressWasUnblocked()
        {
            var player = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = Create
                .Game()
                .PlayerWithCardsInProgress(player, 1)
                .BlockCardInProgress()
                .Please();

            game.NextRound();

            var unblockedCard = game.Columns.InProgress.Cards.First(_ => !_.IsBlocked && _.Player == player);
            Assert.False(unblockedCard.IsBlocked);
        }

        [Test]
        public void BlockedCardInTestingWasUnblocked()
        {
            var player = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = Create
                .Game()
                .PlayerWithCardsInTesting(player, 1)
                .BlockCardInTesting()
                .Please();

            game.NextRound();

            var playerCard = game.FindCards(_ => _.Player == player).Single();
            Assert.False(playerCard.IsBlocked);
        }

        [Test]
        public void CardInProgressWasMovedToTesting()
        {
            var player = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = Create
                .Game()
                .PlayerWithCardsInProgress(player, 1)
                .Please();

            game.NextRound();

            var playerCard = game.FindCards(_ => _.Player == player).Single();
            Assert.That(playerCard.Column.Type, Is.EqualTo(ColumnType.Testing));
        }

        [Test]
        public void CardInTestingWasMovedToDone()
        {
            var player = Create
                .Player()
                .WithTailsCoin()
                .Please();
            var game = Create
                .Game()
                .PlayerWithCardsInTesting(player, 1)
                .Please();

            game.NextRound();

            var playerCard = game.FindCards(_ => _.Player == player).Single();
            Assert.That(playerCard.Column.Type, Is.EqualTo(ColumnType.Done));
        }
    }
}