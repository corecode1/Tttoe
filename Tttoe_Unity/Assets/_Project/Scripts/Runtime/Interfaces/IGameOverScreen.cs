using System;
using Zenject;

namespace com.tttoe.runtime
{
    public interface IGameOverScreen : IActivatable, IInitializable, IDisposable
    {
        public event Action OnPlayAgain;
        public void ShowGameOverInfo(GameOverCheckResult result, TileOccupation winner);
    }
}