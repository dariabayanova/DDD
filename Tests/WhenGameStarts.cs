using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WhenGameStarts
    {
        [Test]
        public void ToDoColumnHasNoCards()
        {
            var game = new Game();
            var todoCards = game.Columns.ToDo.Cards;

            Assert.AreEqual(0, todoCards.Count);
        }
    }

    public class Game
    {
        public Columns Columns { get; } = new Columns();
    }

    public class Columns
    {
        public Column ToDo { get; } = new Column();
    }

    public class Column
    {
        public List<Card> Cards { get; } = new List<Card>();
    }

    public class Card
    {
    }
}