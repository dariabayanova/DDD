using System.Runtime.InteropServices.WindowsRuntime;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

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

        public GameBuilder Game()
        {
            return new GameBuilder();
        }

        public StatisticBuilder Statistic()
        {
            return new StatisticBuilder();
        }
    }
}