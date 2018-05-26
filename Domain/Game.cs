using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Game
    {
        private readonly int defaultCardsCount = 10;
        public Columns Columns { get; } = new Columns();
        public List<Player> Players { get; private set; }

        public void Start(List<Player> players)
        {
            InitPlayers(players);

            GenerateCards(defaultCardsCount);
        }

        private void InitPlayers(List<Player> players)
        {
            Players = players;

            foreach (var player in players)
            {
                player.JoinGame(this);
            }
        }

        public void NextRound()
        {
            foreach (var player in Players)
            {
                player.Play();
            }
        }

        public virtual void GenerateCards(int cardsCount)
        {
            for (var i = 0; i < cardsCount; i++)
            {
                var card = new Card();
                Columns.Backlog.Cards.Add(card);
            }
        }

        public Card GetCardFromBackLog()
        {
            return Columns.Backlog.Cards.First();
        }

        public void MoveToInProgress(Card card)
        {
            Columns.Backlog.Cards.Remove(card);
            Columns.InProgress.Cards.Add(card);
        }
    }
}