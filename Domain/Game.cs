using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Game
    {
        private readonly int defaultCardsCount = 10;
        public Columns Columns { get; } = new Columns();
        public HashSet<Player> Players { get; private set; } = new HashSet<Player>();

        public void Start()
        {
            GenerateCards(defaultCardsCount);
        }

        public void Join(Player player)
        {
            Players.Add(player);
            player.JoinGame(this);
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
            var cardsInProgress = Columns.InProgress.Cards;

            if (!Columns.InProgress.HasWIP || cardsInProgress.Count < Columns.InProgress.WIP)
            {
                Columns.Backlog.RemoveCard(card);
                card.Player = player;
                Columns.InProgress.AddCard(card);
            }
        }

        public void MoveCardFromInProgressToTesting(Card card)
        {
            if (card.IsBlocked)
            {
                return;
            }

            var cardsInTesting = Columns.Testing.Cards;

            if (!Columns.Testing.HasWIP || cardsInTesting.Count < Columns.Testing.WIP)
            {
                Columns.InProgress.RemoveCard(card);
                Columns.Testing.AddCard(card);
            }
        }

        public void MoveCardFromTestingToDone(Card card)
        {
            Columns.Testing.RemoveCard(card);
            Columns.Done.AddCard(card);
        }

        public Card GetCardFromInProgress(Player player)
        {
            return Columns.InProgress.Cards.First(_ => _.Player == player);
        }

        public Card GetCardFromTesting(Player player)
        {
            return Columns.Testing.Cards.First(_ => _.Player == player);
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