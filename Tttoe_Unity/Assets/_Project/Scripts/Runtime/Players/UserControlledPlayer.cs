using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;

namespace com.tttoe.runtime
{
    public class UserControlledPlayer : PlayerBase, IUserControlledPlayer
    {
        private IBoard _board;

        public UserControlledPlayer(TileOccupation occupation, IGameEvents events, IBoard board) : base(events, occupation)
        {
            _board = board;
        }

        protected override PlayerType Type { get; } = PlayerType.LocalUser;

        public override void Initialize()
        {
            _events.OnTileClicked += HandleTileClicked;
        }

        public override void Dispose()
        {
            _events.OnTileClicked -= HandleTileClicked;
        }
        
        private void HandleTileClicked(BoardTilePosition position)
        {
            if (!CanTriggerMove())
            {
                return;
            }

            if (_board.IsTileOccupied(position))
            {
                return;
            }

            _events.TriggerMoveRequested(position, Occupation);
            SignalMoveEnded();
        }
    }
}