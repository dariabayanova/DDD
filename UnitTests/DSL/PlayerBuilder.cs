using Domain;
using Moq;

namespace UnitTests.DSL
{
    public class PlayerBuilder
    {
        private readonly Create Create = new Create();
        private Mock<Coin> coinMock;

        public PlayerBuilder WithHeadsCoin()
        {
            coinMock = Create.Coin().WithHeads().Please();
            return this;
        }

        public PlayerBuilder WithTailsCoin()
        {
            coinMock = Create.Coin().WithTails().Please();
            return this;
        }

        public Mock<Player> Please()
        {
            var playerMock = new Mock<Player>();
            playerMock.Setup(_ => _.GetCoin()).Returns(coinMock.Object);

            return playerMock;
        }
    }
}