using System;
using Zenject;

namespace com.tttoe.runtime
{
    public interface IAppView : IActivatable, IInitializable, IDisposable
    {
        event Action<GameModeType> OnGameModeSelected;
    }
}