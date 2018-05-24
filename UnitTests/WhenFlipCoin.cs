using System;
using Domain;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenFlipCoin
    {
        [Test]
        public void CoinCallsRandomizer()
        {
            var coinMock = new Mock<Coin>();
            coinMock.Setup(_ => _.GetRandomizer()).Returns(RandomMock().Object);

            coinMock.Object.Flip();

            coinMock.Verify(_ => _.GetRandomizer(), Times.Once);
        }

        private static Mock<Random> RandomMock()
        {
            var random = new Mock<Random>();
            random.Setup(_ => _.NextDouble()).Returns(0.1);
            return random;
        }
    }
}