using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Columns : List<Column>
    {
        public Column ToDo
        {
            get { return this.First(_ => _.Type == ColumnType.ToDo); }
        }

        public Columns()
        {
            Add(new Column(ColumnType.ToDo));
            Add(new Column(ColumnType.InProgress));
            Add(new Column(ColumnType.Done));
        }
    }
}