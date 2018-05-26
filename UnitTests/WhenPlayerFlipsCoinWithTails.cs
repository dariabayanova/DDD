using System.Collections.Generic;
using System.Linq;
using Domain;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenPlayerFlipsCoinWithTails
    {
        [Test]
        public void NewCardAssignedToPlayer()
        {
            var playerMock = new Mock<Player>();
            var coinMock = GetCoinMock();
            playerMock.Setup(_ => _.GetCoin()).Returns(coinMock.Object);
            var game = new Game();
            game.Start(new List<Player>{playerMock.Object});

            game.NextRound();

            var oneCardInProgress = game.Columns.InProgress.Cards.Single();
            Assert.That(oneCardInProgress.Player, Is.EqualTo(playerMock.Object));
        }

        private static Mock<Coin> GetCoinMock()
        {
            var coin = new Mock<Coin>();
            coin.Setup(_ => _.Flip()).Returns(SideOfCoin.Tails);
            return coin;
        }
    }
}