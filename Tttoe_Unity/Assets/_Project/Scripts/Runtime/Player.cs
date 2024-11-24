using com.tttoe.runtime.Interfaces;
using Zenject;

namespace com.tttoe.runtime
{
    public class Player : IPlayer
    {
        private IBoard _board;

        public TileOccupation Occupation { get; }

        public Player(IBoard board, TileOccupation occupation)
        {
            Occupation = occupation;
            _board = board;
        }
        
        public class Factory : PlaceholderFactory<TileOccupation, Player>
        {
        }
    }
}