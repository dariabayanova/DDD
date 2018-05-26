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
            var playerMock = Create.Player().WithTailsCoin().Please();
            var game = new Game();
            game.Start(new List<Player>{playerMock.Object});

            game.NextRound();

            var oneCardInProgress = game.FindCards(_ => _.Column.Type == ColumnType.InProgress).Single();
            Assert.That(oneCardInProgress.Player, Is.EqualTo(playerMock.Object));
        }
    }
}