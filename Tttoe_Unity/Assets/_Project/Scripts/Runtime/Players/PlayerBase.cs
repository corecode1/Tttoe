using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;

namespace com.tttoe.runtime
{
    public abstract class PlayerBase : IPlayer
    {
        protected enum State
        {
            Idle,
            TurnInProgress,
            MoveFired
        }

        protected State _state { get; private set; } = State.Idle;
        protected readonly IGameEvents _events;

        public TileOccupation Occupation { get; }

        protected PlayerBase(IGameEvents events, TileOccupation occupation)
        {
            _events = events;
            Occupation = occupation;
        }

        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
        }

        public async UniTask MakeTurn()
        {
            ChangeState(State.TurnInProgress);
            await UniTask.WaitUntil(IsMoveTriggered);
            ChangeState(State.Idle);
        }

        private void ChangeState(State newState)
        {
            State oldState = _state;
            _state = newState;

            if (CanTriggerMove())
            {
                HandleMoveStart(oldState, newState);
            }
        }

        protected void SignalMoveEnded()
        {
            ChangeState(State.MoveFired);
        }

        protected virtual void HandleMoveStart(State oldState, State newState)
        {
        }

        protected bool CanTriggerMove() => _state == State.TurnInProgress;
        private bool IsMoveTriggered() => _state == State.MoveFired;
    }
}