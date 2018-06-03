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
                var testingCards = CurrentGame.Columns.Testing.Cards.Where(_ => _.Player == this);
                var testingHasUnblockedCards = testingCards.Any(_ => !_.IsBlocked);
                var testingHasBlockedCards = testingCards.Any(_ => _.IsBlocked);
                var inProgressCards = CurrentGame.Columns.InProgress.Cards.Where(_ => _.Player == this);
                var inProgressHasBlockedCards = inProgressCards.Any(_ => _.IsBlocked);
                var inProgressHasUnblockedCards = inProgressCards.Any(_ => !_.IsBlocked);

                if (testingHasUnblockedCards)
                {
                    MoveCardFromTestingToDone();
                }
                else if (testingHasBlockedCards)
                {
                    UnblockCardInTesting();
                }
                else if (inProgressHasUnblockedCards)
                {
                    MoveCardFromInProgressToTesting();
                }
                else if (inProgressHasBlockedCards)
                {
                    UnblockCardInProgress();
                }
                else
                {
                    GetNewCardFromBacklog();
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
            var cardInProgress = CurrentGame.Columns.InProgress.Cards.FirstOrDefault(_ => !_.IsBlocked && _.Player == this);
            if (cardInProgress != null)
            {
                cardInProgress.IsBlocked = true;
            }
        }

        private void UnblockCardInProgress()
        {
            var blockedCardInProgress =
                CurrentGame.Columns.InProgress.Cards.FirstOrDefault(_ => _.IsBlocked && _.Player == this);
            blockedCardInProgress.IsBlocked = false;
        }

        private void UnblockCardInTesting()
        {
            var blockedCardInTesting =
                CurrentGame.Columns.Testing.Cards.First(_ => _.IsBlocked && _.Player == this);
            blockedCardInTesting.IsBlocked = false;
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