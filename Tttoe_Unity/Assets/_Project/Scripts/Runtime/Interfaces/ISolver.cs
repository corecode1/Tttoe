namespace com.tttoe.runtime.Interfaces
{
    public interface ISolver
    {
        GameOverCheckResult CheckForGameOver(out TileOccupation? winner);
    }
}