using System;
using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class TToeApp : IInitializable, IDisposable
    {
        private readonly IFactory<GameModeType, IGameMode> _gameModeFactory;
        private readonly IAppView _view;
        private readonly IGameEvents _events;

        public TToeApp(
            IAppView view,
            IGameEvents events,
            IFactory<GameModeType, IGameMode> gameModeFactory)
        {
            _events = events;
            _view = view;
            _gameModeFactory = gameModeFactory;
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

        private async UniTask StartMatch(GameModeType gameModeType)
        {
            IGameMode gameMode = _gameModeFactory.Create(gameModeType);
            gameMode.Initialize();
            _events.TriggerMatchStart();
            
            await gameMode.StartGame();

            GameOverCheckResult result = GameOverCheckResult.None;

            while (result == GameOverCheckResult.None)
            {
                result = await gameMode.MakeTurn();
            }

            Debug.Log($"Game over! result: {result}");
        }
    }
}