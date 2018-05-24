using System.Collections.Generic;

namespace Domain
{
    public class Column
    {
        public virtual ColumnType Type { get; }
        public List<Card> Cards { get; } = new List<Card>();
    }
}