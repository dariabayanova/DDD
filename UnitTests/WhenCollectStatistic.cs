using Domain;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenCollectStatistic : BaseTest
    {
        [Test]
        public void GameExecutesNextRound()
        {
	        var gameMock = new Mock<Game>();
	        var statisticsMock = Create
		        .Statistic()
		        .WithWIP(1)
		        .WithPlayers(3)
		        .WithRounds(15)
		        .WithGame(gameMock)
		        .Please();

	        statisticsMock.Object.Collect();

	        gameMock.Verify(_ => _.NextRound(), Times.Exactly(15));
        }
    }
}