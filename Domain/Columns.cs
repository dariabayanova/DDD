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

        public Column Done
        {
            get { return this.First(_ => _.Type == ColumnType.Done); }
        }

        public Columns()
        {
            Add(new BacklogColumn());
            Add(new InProgressColumn());
            Add(new TestingColumn());
            Add(new DoneColumn());
        }
    }
}