using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;

namespace com.tttoe.runtime
{
    public class UserControlledPlayer : PlayerBase, IUserControlledPlayer
    {
        public UserControlledPlayer(TileOccupation occupation, IGameEvents events) : base(events, occupation)
        {
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

            _events.TriggerMove(position, Occupation);
            SignalMoveEnded();
        }
    }
}