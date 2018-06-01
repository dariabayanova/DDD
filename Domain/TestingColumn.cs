namespace Domain
{
    public class TestingColumn : Column
    {
        private int infinityWIP = -1;

        public override ColumnType Type => ColumnType.Testing;
        public int WIP { get; set; } = -1;
        public bool HasWIP => WIP != infinityWIP;
    }
}