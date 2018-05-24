using Domain;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenFlipCoin
    {
        [Test]
        public void CoinReturnsTails()
        {
            var coin = new Coin();

            var tails = coin.Flip();

            Assert.That(tails, Is.EqualTo(SideOfCoin.Tails));
        }
    }
}