namespace Domain
{
    public class Coin
    {
        public virtual SideOfCoin Flip()
        {
            return SideOfCoin.Tails;
        }
    }
}