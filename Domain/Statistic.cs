namespace Domain
{
    public class Statistic
    {
        public int Wip { get; }
        public int PlayersCount { get; }
        public int RoundsCount { get; }

        public Statistic(int wip, int playersCount, int roundsCount)
        {
            Wip = wip;
            PlayersCount = playersCount;
            RoundsCount = roundsCount;
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
            var game = CreateGame();

            for (var i = 0; i < RoundsCount; i++)
            {
                game.NextRound();
            }
        }
    }
}