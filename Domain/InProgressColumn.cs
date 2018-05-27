namespace Domain
{
    public class InProgressColumn : Column
    {
        private int infinityWIP = -1;

        public override ColumnType Type => ColumnType.InProgress;
        public int WIP { get; set; } = -1;
        public bool HasWIP => WIP != infinityWIP;
    }
}