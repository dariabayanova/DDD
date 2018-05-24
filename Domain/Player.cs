namespace Domain
{
    public class Player
    {
        public virtual Coin GetCoin() => new Coin();

        public void Play()
        {
            var coin = GetCoin();
            coin.Flip();
        }
    }
}