namespace com.tttoe.runtime
{
    public readonly struct MatchMove
    {
        public readonly BoardTilePosition Position;
        public readonly TileOccupation Previous;
        public readonly TileOccupation Next;

        public MatchMove(BoardTilePosition position, TileOccupation prev, TileOccupation next)
        {
            Position = position;
            Previous = prev;
            Next = next;
        }
    }
}