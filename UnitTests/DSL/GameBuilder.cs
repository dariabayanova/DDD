using System.Collections.Generic;
using Domain;
using Moq;

namespace UnitTests.DSL
{
    public class GameBuilder
    {
        private IMock<Player> playerMock;
        private readonly Game game = new Game();

        public GameBuilder PlayerWithCardsInProgress(IMock<Player> playerMock, int cardsCount)
        {
            this.playerMock = playerMock;
            game.Start(new List<Player>{playerMock.Object});

            CreateCardsInProgress(playerMock, cardsCount);

            return this;
        }

        public GameBuilder WithWIPInProgress(int wip)
        {
            game.Columns.InProgress.WIP = wip;
            return this;
        }

        public Game Please()
        {
            return game;
        }

        private void CreateCardsInProgress(IMock<Player> playerMock, int cardsCount)
        {
            for (var i = 0; i < cardsCount; i++)
            {
                var card = game.GetCardFromBackLog();
                game.MoveToInProgress(card, playerMock.Object);
            }
        }
    }
}