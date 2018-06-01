using System.Collections.Generic;
using System.Linq;
using Domain;
using Moq;

namespace UnitTests.DSL
{
    public class GameBuilder
    {
        private Player player;
        private readonly Game game = new Game();

        public GameBuilder PlayerWithCardsInProgress(Player player, int cardsCount)
        {
            this.player = player;
            game.Start(new List<Player> {player});

            CreateCardsInProgress(player, cardsCount);

            return this;
        }

        public GameBuilder WithWipInProgress(int wip)
        {
            game.Columns.InProgress.WIP = wip;
            return this;
        }

        public Game Please()
        {
            return game;
        }

        private void CreateCardsInProgress(Player player, int cardsCount)
        {
            for (var i = 0; i < cardsCount; i++)
            {
                var card = game.GetCardFromBackLog();
                game.MoveToInProgress(card, player);
            }
        }

        public GameBuilder BlockCardInProgress()
        {
            var cardInProgress = game.Columns.InProgress.Cards.First(_ => !_.IsBlocked && _.Player == player);
            cardInProgress.IsBlocked = true;
            return this;
        }
    }
}