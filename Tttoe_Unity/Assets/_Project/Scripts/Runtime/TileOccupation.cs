namespace com.tttoe.runtime
{
    public struct TileOccupation
    {
        public static readonly TileOccupation NonOccupied = new TileOccupation(1);
        public static readonly TileOccupation Player1 = new TileOccupation(2);
        public static readonly TileOccupation Player2 = new TileOccupation(3);

        private readonly int value;

        private TileOccupation(int value)
        {
            this.value = value;
        }
    }
}