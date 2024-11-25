namespace com.tttoe.runtime.Interfaces
{
    public interface ISolver
    {
        int MinBoardSize { get; }
        GameOverCheckResult CheckForGameOver(out TileOccupation? winner);
    }
}