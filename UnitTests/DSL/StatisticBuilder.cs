using Domain;
using Moq;
using StatisticDomain;

namespace UnitTests.DSL
{
    public class StatisticBuilder
    {
        private Game game;
        private int wip;
        private int playersCount;
        private int roundsCount;
        private int times;

        public StatisticBuilder WithWIP(int wip)
        {
            this.wip = wip;
            return this;
        }

        public StatisticBuilder WithPlayers(int playersCount)
        {
            this.playersCount = playersCount;
            return this;
        }

        public StatisticBuilder WithRounds(int roundsCount)
        {
            this.roundsCount = roundsCount;
            return this;
        }

        public StatisticBuilder WithGame(Game game)
        {
            this.game = game;

            return this;
        }
        
        public StatisticBuilder Times(int times)
        {
            this.times = times;

            return this;
        }

        public Statistic Please()
        {
            var statisticMock = new Mock<Statistic>(wip, playersCount, roundsCount, times);

            statisticMock.Setup(_ => _.CreateGame()).Returns(game);

            return statisticMock.Object;
        }
    }
}