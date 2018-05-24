using Domain;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenFlipCoin
    {
        [Test]
        public void CoinReturnsTails()
        {
            var coinMock = new Mock<Coin>();
            coinMock.Setup(_ => _.Flip()).Returns(SideOfCoin.Tails);

            var tails = coinMock.Object.Flip();

            Assert.That(tails, Is.EqualTo(SideOfCoin.Tails));
        }

        [Test]
        public void CoinReturnsHeads()
        {
            var coinMock = new Mock<Coin>();
            coinMock.Setup(_ => _.Flip()).Returns(SideOfCoin.Heads);

            var heads = coinMock.Object.Flip();

            Assert.That(heads, Is.EqualTo(SideOfCoin.Heads));
        }
    }
}