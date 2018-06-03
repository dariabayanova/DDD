using UnitTests.DSL;

namespace StatisticUnitTests.DSL
{
    public class Create
    {
        public StatisticBuilder Statistic()
        {
            return new StatisticBuilder();
        }

        public CoinBuilder Coin()
        {
            return new CoinBuilder();
        }

        public PlayerBuilder Player()
        {
            return new PlayerBuilder();
        }

        public GameBuilder Game()
        {
            return new GameBuilder();
        }
    }
}