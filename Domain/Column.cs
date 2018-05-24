using System.Collections.Generic;

namespace Domain
{
    public class Column
    {
        public Column(ColumnType type)
        {
            Type = type;
        }

        public ColumnType Type { get; }
        public List<Card> Cards { get; } = new List<Card>();
    }
}