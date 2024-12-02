using System;
using Zenject;

namespace com.tttoe.runtime.Interfaces
{
    public interface IMatchView : IInitializable, IDisposable, IActivatable
    {
        // TODO: show current player, timer, menu button, undo
        public event Action OnRevertRequested;

        public void SetRevertAvailability(RevertAvailability availability);
    }
}