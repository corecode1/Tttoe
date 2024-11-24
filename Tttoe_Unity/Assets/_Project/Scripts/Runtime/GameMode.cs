using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public class GameMode : IGameMode
    {
        Player[] _players;

        public GameMode(Player.Factory playerFactory)
        {
            _players = new[]
            {
                playerFactory.Create(TileOccupation.X),
                playerFactory.Create(TileOccupation.O),
            };
        }
    }
}