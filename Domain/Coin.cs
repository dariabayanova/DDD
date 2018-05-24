using System;

namespace Domain
{
    public class Coin
    {
        public virtual Random GetRandomizer() => new Random(Guid.NewGuid().GetHashCode());

        public SideOfCoin Flip()
        {
            var randomizer = GetRandomizer();
            return randomizer.NextDouble() > 0.5 ? SideOfCoin.Heads : SideOfCoin.Tails;
        }
    }
}