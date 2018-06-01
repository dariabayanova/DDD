using System.Linq;

namespace Domain
{
    public class Player
    {
        public virtual Coin coin { get; }

        public Player()
        {
            coin = new Coin();
        }

        public Game CurrentGame { get; set; }

        // Очень понятный код, выражающий поведение домена. Молодцы!
        public void Play(string action)
        {
            var sideOfCoin = FlipCoin();

            if (sideOfCoin == SideOfCoin.Tails)
            {
                switch (action)
                {
                    case "newCard":
                        GetNewCardFromBacklog();
                        break;
                    case "unblockCard":
                        UnblockCardInProgress();
                        break;
                    case "moveToTesting":
                        MoveCardFromInProgressToTesting();
                        break;
                }
            }

            if (sideOfCoin == SideOfCoin.Heads)
            {
                BlockCardInProgress();
                GetNewCardFromBacklog();
            }
        }


        private SideOfCoin FlipCoin()
        {
            var coin = this.coin;
            var sideOfCoin = coin.Flip();
            return sideOfCoin;
        }

        private void BlockCardInProgress()
        {
            var cardInProgress = CurrentGame.Columns.InProgress.Cards.First(_ => !_.IsBlocked && _.Player == this);
            cardInProgress.IsBlocked = true;
        }

        private void UnblockCardInProgress()
        {
            var blockedCardInProgress =
                CurrentGame.Columns.InProgress.Cards.First(_ => _.IsBlocked && _.Player == this);
            blockedCardInProgress.IsBlocked = false;
        }

        private void MoveCardFromInProgressToTesting()
        {
            var card = CurrentGame.GetCardFromInProgress(this);
            CurrentGame.MoveCardFromInProgressToTesting(card, this);
        }

        private void GetNewCardFromBacklog()
        {
            var card = CurrentGame.GetCardFromBackLog();
            CurrentGame.MoveToInProgress(card, this);
        }

        public void JoinGame(Game game)
        {
            CurrentGame = game;
        }
    }
}