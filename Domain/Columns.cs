using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Columns : List<Column>
    {
        public Column Backlog
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