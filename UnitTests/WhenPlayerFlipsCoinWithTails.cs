using System.Collections.Generic;
using System.Linq;
using Domain;
using Moq;
using NUnit.Framework;
using UnitTests.DSL;

namespace UnitTests
{
    [TestFixture]
    public class WhenPlayerFlipsCoinWithTails : BaseTest
    {
        [Test]
        public void NewCardAssignedToPlayer()
        {
            var playerMock = Create.Player().WithTailsCoin().Please();
            var game = new Game();
            game.Start(new List<Player>{playerMock.Object});

            game.NextRound();

            var oneCardInProgress = game.Columns.InProgress.Cards.Single();
            Assert.That(oneCardInProgress.Player, Is.EqualTo(playerMock.Object));
        }
    }
}