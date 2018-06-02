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
	        var statistics = Create
		        .Statistic()
		        .WithWIP(1)
		        .WithPlayers(3)
		        .WithRounds(15)
		        .WithGame(gameMock.Object)
		        .Times(1)
		        .Please();

	        statistics.Collect();

	        gameMock.Verify(_ => _.NextRound(), Times.Exactly(15));
        }

	    [Test]
	    public void GameRoundsShouldBeEqualsRoundsNumberPerGameMultipliedNumberOfTimes()
	    {
		    var gameMock = new Mock<Game>();
		    var statistics = Create
			    .Statistic()
			    .WithWIP(1)
			    .WithPlayers(3)
			    .WithRounds(15)
			    .WithGame(gameMock.Object)
			    .Times(1000)
			    .Please();

		    statistics.Collect();

		    gameMock.Verify(_ => _.NextRound(), Times.Exactly(15 * 1000));
	    }
	    
	    [Test]
	    public void ThroughputRateEqualsCardsInDoneColumn()
	    {
		    var game = CreateGameWithOneCardInTesting();

		    var statistic = Create
			    .Statistic()
			    .WithGame(game)
			    .WithRounds(1)
			    .Times(1)
			    .Please();

		    var throughputRate = statistic.Collect();
		    var doneCards = game.Columns.Done.Cards;
		    Assert.That(throughputRate, Is.EqualTo(doneCards.Count));
	    }

	    private Game CreateGameWithOneCardInTesting()
	    {
		    var player = Create
			    .Player()
			    .WithTailsCoin()
			    .Please();
		    var game = Create
			    .Game()
			    .PlayerWithCardsInTesting(player, 1)
			    .Please();
		    return game;
	    }
    }
}