using System;
using com.tttoe.runtime.Interfaces;
using Zenject;

namespace com.tttoe.runtime
{
    public class TToeApp : IInitializable, IDisposable
    {
        private readonly IStartScreen _startScreen;
        private readonly IGameOverScreen _gameOverScreen;
        private readonly IGameEvents _events;
        private readonly BoardPresenter _boardPresenter;
        private readonly MatchPresenter _matchPresenter;

        public TToeApp(
            IStartScreen startScreen,
            IGameOverScreen gameOverScreen,
            IGameEvents events,
            BoardPresenter boardPresenter,
            MatchPresenter matchPresenter)
        {
            _matchPresenter = matchPresenter;
            _boardPresenter = boardPresenter;
            _events = events;
            _startScreen = startScreen;
            _gameOverScreen = gameOverScreen;
        }

        public void Initialize()
        {
            _startScreen.OnGameModeSelected += HandleGameModeSelected;
            _gameOverScreen.OnPlayAgain += HandlePlayAgain;
            
            _boardPresenter.Initialize();
            _matchPresenter.Initialize();
            _startScreen.Initialize();
            _gameOverScreen.Initialize();
            _startScreen.Activate(true);
            _events.OnMatchEnd += HandleMatchEnd;
        }

        public void Dispose()
        {
            _events.OnMatchEnd -= HandleMatchEnd;
            _gameOverScreen.OnPlayAgain -= HandlePlayAgain;

            _boardPresenter.Dispose();
            _matchPresenter.Dispose();
            _startScreen.Dispose();
            _gameOverScreen.Dispose();
        }

        private void HandleMatchEnd(IMatchModel match)
        {
            _gameOverScreen.Activate(true);
        }

        private void HandleGameModeSelected(GameModeType gameMode)
        {
            _startScreen.Activate(false);
            StartMatch(gameMode);
        }

        private void HandlePlayAgain()
        {
            _gameOverScreen.Activate(false);
            _startScreen.Activate(true);
            
            _events.TriggerPlayAgain();
        }

        private void StartMatch(GameModeType gameModeType)
        {
            _events.TriggerMatchStart(gameModeType);
        }
    }
}