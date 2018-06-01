using System.Linq;

namespace Domain
{
    public class Player
    {
        public Game CurrentGame { get; set; }
        // TODO: Раз уж у Player есть явная зависимость от Coin, может сделаем ее явной (через конструктор)?
        public virtual Coin GetCoin() => new Coin();

        // Очень понятный код, выражающий поведение домена. Молодцы!
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
            var cardInProgress = CurrentGame
                .FindCards(_ => _.Column.Type == ColumnType.InProgress &&
                                _.Player == this &&
                                !_.IsBlocked)
                .First();
            cardInProgress.IsBlocked = true;
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