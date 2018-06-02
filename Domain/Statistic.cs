namespace Domain
{
    public class Statistic
    {
        public int Wip { get; }
        public int PlayersCount { get; }
        public int RoundsCount { get; }
        public int Times { get; }

        public Statistic(int wip, int playersCount, int roundsCount, int times)
        {
            Wip = wip;
            PlayersCount = playersCount;
            RoundsCount = roundsCount;
            Times = times;
        }

        public virtual Game CreateGame()
        {
            var game = new Game();
            game.Columns.InProgress.WIP = Wip;
            game.Columns.Testing.WIP = Wip;

            for (var i = 0; i < PlayersCount; i++)
            {
                game.Join(new Player());
            }

            return game;
        }

        public void Collect()
        {
            for (var i = 0; i < Times; i++)
            {
                CollectExperiment();
            }
        }

        private void CollectExperiment()
        {
            var game = CreateGame();

            for (var j = 0; j < RoundsCount; j++)
            {
                game.NextRound();
            }
        }
    }
}