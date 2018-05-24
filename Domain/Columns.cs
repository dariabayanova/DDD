using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Columns : List<Column>
    {
        public Column Backlog
        {
            get { return this.First(_ => _.Type == ColumnType.Backlog); }
        }

        public Column InProgress
        {
            get { return this.First(_ => _.Type == ColumnType.InProgress); }
        }

        public Column Testing
        {
            get { return this.First(_ => _.Type == ColumnType.Testing); }
        }

        public Columns()
        {
            Add(new Column(ColumnType.Backlog));
            Add(new Column(ColumnType.InProgress));
            Add(new Column(ColumnType.Testing));
            Add(new Column(ColumnType.Done));
        }
    }
}