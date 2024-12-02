using System;
using Zenject;

namespace com.tttoe.runtime
{
    public interface IStartScreen : IActivatable, IInitializable, IDisposable
    {
        event Action<GameModeType> OnGameModeSelected;
    }
}