namespace Domain
{
    public class Columns
    {
        public BacklogColumn Backlog { get; } = new BacklogColumn();
        public InProgressColumn InProgress { get; } = new InProgressColumn();
        public TestingColumn Testing { get; } = new TestingColumn();
        public DoneColumn Done { get; } = new DoneColumn();
    }
}