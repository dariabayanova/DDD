using Domain;
using Moq;

namespace UnitTests.DSL
{
    public class CoinBuilder
    {
        private SideOfCoin sideOfCoin = SideOfCoin.Heads;

        public CoinBuilder WithTails()
        {
            sideOfCoin = SideOfCoin.Tails;
            return this;
        }

        public CoinBuilder WithHeads()
        {
            sideOfCoin = SideOfCoin.Heads;
            return this;
        }

        public Mock<Coin> Please()
        {
            var coin = new Mock<Coin>();
            coin.Setup(_ => _.Flip()).Returns(sideOfCoin);
            return coin;
        }
    }
}