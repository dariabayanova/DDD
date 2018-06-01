﻿using System.Linq;
using Domain;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenInProgressColumnHasWip : BaseTest
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
                .WithWipInProgress(2)
                .PlayerWithCardsInProgress(player, 1)
                .Please();

            game.NextRound();

            var playerCards = player.Object.CurrentGame.FindCards(_ => _.Column.Type == ColumnType.InProgress);
            var cardsWithPlayer =
                game.FindCards(_ => _.Column.Type == ColumnType.InProgress && _.Player == player.Object);
            CollectionAssert.AreEqual(playerCards, cardsWithPlayer);
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
                .WithWipInProgress(2)
                .PlayerWithCardsInProgress(player, 2)
                .Please();

            game.NextRound();

            var cardsInProgress = game.FindCards(_ => _.Column.Type == ColumnType.InProgress);
            Assert.That(cardsInProgress.Count, Is.EqualTo(2));
        }
    }
}