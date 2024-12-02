using System;
using Zenject;

namespace com.tttoe.runtime
{
    public class TToeApp : IInitializable, IDisposable
    {
        private readonly IAppView _view;
        private readonly IGameEvents _events;

        public TToeApp(
            IAppView view,
            IGameEvents events)
        {
            _events = events;
            _view = view;
        }

        public void Initialize()
        {
            _view.OnGameModeSelected += HandleGameModeSelected;
            _view.Initialize();
            _view.Activate(true);
        }

        public void Dispose()
        {
            _view.Dispose();
        }

        private void HandleGameModeSelected(GameModeType gameMode)
        {
            _view.Activate(false);
            StartMatch(gameMode);
        }

        private void StartMatch(GameModeType gameModeType)
        {
            _events.TriggerMatchStart(gameModeType);
        }
    }
}