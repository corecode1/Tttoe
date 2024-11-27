namespace com.tttoe.runtime.Interfaces
{
    public interface IMoveFinder
    {
        public bool TryFindMove(out BoardTilePosition? move);
    }
}