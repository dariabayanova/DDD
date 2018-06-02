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

        public double Collect()
        {
            var totalCardsInDone = 0;

            for (var i = 0; i < Times; i++)
            {
                var game = ExecuteGame();
                var doneCards = game.Columns.Done.Cards;
                totalCardsInDone += doneCards.Count;
            }

            return (double)totalCardsInDone/Times;
        }

        private Game ExecuteGame()
        {
            var game = CreateGame();

            for (var j = 0; j < RoundsCount; j++)
            {
                game.NextRound();
            }

            return game;
        }
    }
}