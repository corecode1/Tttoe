using System;
using Zenject;

namespace com.tttoe.runtime
{
    public class TToeApp : IInitializable, IDisposable
    {
        private readonly IAppView _view;
        private readonly IGameEvents _events;
        private readonly BoardPresenter _boardPresenter;
        private readonly MatchPresenter _matchPresenter;

        public TToeApp(
            IAppView view,
            IGameEvents events,
            BoardPresenter boardPresenter,
            MatchPresenter matchPresenter)
        {
            _matchPresenter = matchPresenter;
            _boardPresenter = boardPresenter;
            _events = events;
            _view = view;
        }

        public void Initialize()
        {
            _view.OnGameModeSelected += HandleGameModeSelected;
            
            _boardPresenter.Initialize();
            _matchPresenter.Initialize();
            _view.Initialize();
            _view.Activate(true);
        }

        public void Dispose()
        {
            _boardPresenter.Dispose();
            _matchPresenter.Dispose();
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