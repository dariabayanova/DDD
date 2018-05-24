using Domain;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenPlayerPlays
    {
        [Test]
        public void HeFlipsCoin()
        {
            var playerMock = new Mock<Player>();
            var coinMock = GetCoinMock();
            playerMock.Setup(_ => _.GetCoin()).Returns(coinMock.Object);

            playerMock.Object.Play();

            coinMock.Verify(_ => _.Flip(), Times.Once);
        }

        private static Mock<Coin> GetCoinMock()
        {
            var coin = new Mock<Coin>();
            coin.Setup(_ => _.Flip()).Returns(SideOfCoin.Heads);
            return coin;
        }
    }
}