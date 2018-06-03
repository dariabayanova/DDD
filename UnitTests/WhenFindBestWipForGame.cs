using NUnit.Framework;
using StatisticDomain;

namespace UnitTests
{
    [TestFixture]
    public class WhenFindBestWipForGame : BaseTest
    {
        [Test]
        [Combinatorial]
        public void CanExecuteExperimentWith(
            [Values(1, 2, 3, 4, 5, 6, 7, 8)] int wip,
            [Values(3, 4)] int playersCount,
            [Values(15)] int roundsCount,
            [Values(1000)] int times)
        {
            var statistics = new Statistic(wip, playersCount, roundsCount, times);
            var throughputRate = statistics.CalculateThroughputRate();

            TestContext.WriteLine($"{throughputRate} - throughtput rate for WIP={wip}, players count={playersCount}, rounds count = {roundsCount}, times = {times}.");
        }
    }
}