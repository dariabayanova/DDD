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
        public void Play()
        {
            var sideOfCoin = FlipCoin();

            if (sideOfCoin == SideOfCoin.Tails)
            {
                var testingHasCards = CurrentGame.Columns.Testing.Cards.Any(_ => _.Player == this);
                var inProgressCards = CurrentGame.Columns.InProgress.Cards;
                var inProgressHasCards = inProgressCards.Any(_ => _.Player == this);
                var inProgressHasBlockedCards = inProgressCards.Any(_ => _.IsBlocked && _.Player == this);

                if (testingHasCards)
                {
                    MoveCardFromTestingToDone();
                }
                else if (!inProgressHasCards)
                {
                    GetNewCardFromBacklog();
                }
                else if (inProgressHasBlockedCards)
                {
                    UnblockCardInProgress();
                }
                else
                {
                    MoveCardFromInProgressToTesting();
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
            CurrentGame.MoveCardFromInProgressToTesting(card);
        }

        private void MoveCardFromTestingToDone()
        {
            var card = CurrentGame.GetCardFromTesting(this);
            CurrentGame.MoveCardFromTestingToDone(card);
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