using System.Collections.Generic;

namespace Domain
{
    public class Column
    {
        private List<Card> cards = new List<Card>();

        public virtual ColumnType Type { get; }

        public IList<Card> Cards => cards.AsReadOnly();

        public void AddCard(Card card)
        {
            cards.Add(card);
            card.Column = this;
        }

        public void RemoveCard(Card card)
        {
            cards.Remove(card);
            card.Column = null;
        }
    }
}