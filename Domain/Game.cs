using System;
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
                Columns.Backlog.AddCard(card);
            }
        }

        public Card GetCardFromBackLog()
        {
            return Columns.Backlog.Cards.First();
        }

        public void MoveToInProgress(Card card, Player player)
        {
            var cardsInProgress = FindCards(_ => _.Column.Type == ColumnType.InProgress);
            if (!Columns.InProgress.HasWIP || cardsInProgress.Count < Columns.InProgress.WIP)
            {
                Columns.Backlog.RemoveCard(card);
                card.Player = player;
                Columns.InProgress.AddCard(card);
            }
        }

        public List<Card> FindCards(Func<Card, bool> func)
        {
            var result = new List<Card>();

            result.AddRange(Columns.Backlog.Cards.Where(func));
            result.AddRange(Columns.InProgress.Cards.Where(func));
            result.AddRange(Columns.Testing.Cards.Where(func));
            result.AddRange(Columns.Done.Cards.Where(func));

            return result;
        }
    }
}