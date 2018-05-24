namespace Domain
{
    public class Game
    {
        private readonly int defaultCardsCount = 10;
        public Columns Columns { get; } = new Columns();

        public void Start()
        {
            GenerateCards(defaultCardsCount);
        }

        public virtual void GenerateCards(int cardsCount)
        {
            for (var i = 0; i < cardsCount; i++)
            {
                var card = new Card();
                Columns.Backlog.Cards.Add(card);
            }
        }
    }
}