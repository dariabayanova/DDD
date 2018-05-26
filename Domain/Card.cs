namespace Domain
{
    public class Card
    {
        public Player Player { get; set; }
        public bool IsBlocked { get; set; }
        public Column Column { get; set; }
    }
}