using System.Collections.Generic;

namespace Domain
{
    public class Game
    {
        private readonly int defaultCardsCount = 10;
        public Columns Columns { get; } = new Columns();
        public List<Player> Players { get; private set; }

        public void Start(List<Player> players)
        {
            Players = players;

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