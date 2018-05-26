namespace Domain
{
    public class Player
    {
        private Game CurrentGame { get; set; }
        public virtual Coin GetCoin() => new Coin();

        public void Play()
        {
            var coin = GetCoin();
            var sideOfCoin = coin.Flip();

            if (sideOfCoin == SideOfCoin.Tails)
            {
                var card = CurrentGame.GetCardFromBackLog();
                card.Player = this;
                CurrentGame.MoveToInProgress(card);
            }
        }

        public void JoinGame(Game game)
        {
            CurrentGame = game;
        }
    }
}