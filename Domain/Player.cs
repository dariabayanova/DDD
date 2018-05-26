using System.Linq;

namespace Domain
{
    public class Player
    {
        private Game CurrentGame { get; set; }
        public virtual Coin GetCoin() => new Coin();

        public void Play()
        {
            var sideOfCoin = FlipCoin();

            if (sideOfCoin == SideOfCoin.Tails)
            {
                GetNewCardFromBacklog();
            }

            if (sideOfCoin == SideOfCoin.Heads)
            {
                BlockCardInProgress();
                GetNewCardFromBacklog();
            }
        }

        private SideOfCoin FlipCoin()
        {
            var coin = GetCoin();
            var sideOfCoin = coin.Flip();
            return sideOfCoin;
        }

        private void BlockCardInProgress()
        {
            var cardInProgress = CurrentGame.Columns.InProgress.Cards.First(_ => _.Player == this && !_.IsBlocked);
            cardInProgress.IsBlocked = true;
        }

        private void GetNewCardFromBacklog()
        {
            var card = CurrentGame.GetCardFromBackLog();
            card.Player = this;
            CurrentGame.MoveToInProgress(card);
        }

        public void JoinGame(Game game)
        {
            CurrentGame = game;
        }
    }
}