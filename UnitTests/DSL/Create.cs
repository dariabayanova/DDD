namespace UnitTests.DSL
{
    public class Create
    {
        public CoinBuilder Coin()
        {
            return new CoinBuilder();
        }

        public PlayerBuilder Player()
        {
            return new PlayerBuilder();
        }
    }
}