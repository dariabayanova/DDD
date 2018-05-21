namespace Tests
{
    public class Game
    {
        public Columns Columns { get; } = new Columns();

        public void Start()
        {
            var card = new Card();

            Columns.ToDo.Cards.Add(card);
        }
    }
}