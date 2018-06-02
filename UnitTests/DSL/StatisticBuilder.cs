using Domain;
using Moq;

namespace UnitTests.DSL
{
    public class StatisticBuilder
    {
        private Game game;
        private int wip;
        private int playersCount;
        private int roundsCount;

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

        public Mock<Statistic> Please()
        {
            var statisticMock = new Mock<Statistic>(wip, playersCount, roundsCount);

            statisticMock.Setup(_ => _.CreateGame()).Returns(game);

            return statisticMock;
        }
    }
}