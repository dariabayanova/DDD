namespace Domain
{
    public class Columns
    {
        public Column Backlog { get; } = new BacklogColumn();
        public Column InProgress { get; } = new InProgressColumn();
        public Column Testing { get; } = new TestingColumn();
        public Column Done { get; } = new DoneColumn();
    }
}