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
            var player = Create.Player().WithTailsCoin().Please();
            var game = new Game();
            game.Start(new List<Player>{player});

            game.NextRound();

            var oneCardInProgress = game.Columns.InProgress.Cards.Single();
            Assert.That(oneCardInProgress.Player, Is.EqualTo(player));
        }
    }
}