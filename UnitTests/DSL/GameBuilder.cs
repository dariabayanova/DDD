using System.Linq;
using Domain;

namespace UnitTests.DSL
{
    public class GameBuilder
    {
        private readonly Game game = new Game();

        public GameBuilder()
        {
            game.Start();
        }

        public GameBuilder PlayerWithCardsInProgress(Player player, int cardsCount)
        {
            game.Join(player);

            CreateCardsInProgress(player, cardsCount);

            return this;
        }

        public GameBuilder PlayerWithCardsInTesting(Player player, int cardsCount)
        {
            game.Join(player);

            CreateCardsInTesting(player, cardsCount);

            return this;
        }

        public GameBuilder WithWipInProgress(int wip)
        {
            game.Columns.InProgress.WIP = wip;
            return this;
        }

        public GameBuilder WithWipInTesting(int wip)
        {
            game.Columns.Testing.WIP = wip;
            return this;
        }

        public GameBuilder BlockCardInProgress()
        {
            var cardInProgress = game.Columns.InProgress.Cards.First(_ => !_.IsBlocked);
            cardInProgress.IsBlocked = true;
            return this;
        }

        public GameBuilder BlockCardInTesting()
        {
            var cardInProgress = game.Columns.Testing.Cards.First(_ => !_.IsBlocked);
            cardInProgress.IsBlocked = true;
            return this;
        }

        public Game Please()
        {
            return game;
        }

        private void CreateCardsInTesting(Player player, int cardsCount)
        {
            CreateCardsInProgress(player, cardsCount);

            for (var i = 0; i < cardsCount; i++)
            {
                var card = game.GetCardFromInProgress(player);
                game.MoveCardFromInProgressToTesting(card);
            }
        }

        private void CreateCardsInProgress(Player player, int cardsCount)
        {
            for (var i = 0; i < cardsCount; i++)
            {
                var card = game.GetCardFromBackLog();
                game.MoveToInProgress(card, player);
            }
        }
    }
}