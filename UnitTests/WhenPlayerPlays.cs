using Domain;
using Moq;
using NUnit.Framework;
using UnitTests.DSL;

namespace UnitTests
{
    [TestFixture]
    public class WhenPlayerPlays
    {
        private readonly Create Create = new Create();

        [Test]
        public void HeFlipsCoin()
        {
            var playerMock = new Mock<Player>();
            var coinMock = Create.Coin().WithHeads().Please();

            playerMock.Setup(_ => _.GetCoin()).Returns(coinMock.Object);

            playerMock.Object.Play();

            coinMock.Verify(_ => _.Flip(), Times.Once);
        }
    }
}