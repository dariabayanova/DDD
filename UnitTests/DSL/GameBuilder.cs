using System.Collections.Generic;
using Domain;
using Moq;

namespace UnitTests.DSL
{
    public class GameBuilder
    {
        private Mock<Player> playerMock;
        private readonly Game game = new Game();

        public GameBuilder PlayerWithCardsInProgress(Mock<Player> playerMock)
        {
            this.playerMock = playerMock;
            game.Start(new List<Player>{playerMock.Object});

            var card = game.GetCardFromBackLog();
            card.Player = playerMock.Object;
            game.MoveToInProgress(card);

            return this;
        }

        public Game Please()
        {
            return game;
        }
    }
}