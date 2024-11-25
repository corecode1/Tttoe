using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;

namespace com.tttoe.runtime
{
    public class UserControlledPlayer : IUserControlledPlayer
    {
        private enum State
        {
            Idle,
            TurnInProgress,
            MoveFired
        }

        private State _state = State.Idle;
        private IGameEvents _events;

        public TileOccupation Occupation { get; }

        public UserControlledPlayer(IGameEvents events, TileOccupation occupation)
        {
            _events = events;
            Occupation = occupation;
        }

        public void Initialize()
        {
            _events.OnTileClicked += HandleTileClicked;
        }

        public void Dispose()
        {
            _events.OnTileClicked -= HandleTileClicked;
        }

        public async UniTask MakeTurn()
        {
            _state = State.TurnInProgress;
            await UniTask.WaitUntil(IsMoveFired);
            _state = State.Idle;
        }

        private void HandleTileClicked(BoardTilePosition position)
        {
            if (_state != State.TurnInProgress)
            {
                return;
            }

            _state = State.MoveFired;
            _events.TriggerMove(position, Occupation);
        }

        private bool IsMoveFired() => _state == State.MoveFired;
    }
}