using System.Collections.Generic;
using System.Linq;
using Domain;
using Moq;
using NUnit.Framework;
using UnitTests.DSL;

namespace UnitTests
{
    [TestFixture]
    public class WhenPlayerFlipsCoinWithTails
    {
        private readonly Create Create = new Create();

        [Test]
        public void NewCardAssignedToPlayer()
        {
            var playerMock = new Mock<Player>();
            var coinMock = Create.Coin().WithTails().Please();
            playerMock.Setup(_ => _.GetCoin()).Returns(coinMock.Object);
            var game = new Game();
            game.Start(new List<Player>{playerMock.Object});

            game.NextRound();

            var oneCardInProgress = game.Columns.InProgress.Cards.Single();
            Assert.That(oneCardInProgress.Player, Is.EqualTo(playerMock.Object));
        }
    }
}