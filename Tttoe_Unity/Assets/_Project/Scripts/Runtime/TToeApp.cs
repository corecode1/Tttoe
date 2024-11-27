using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class TToeApp : IInitializable
    {
        private IFactory<GameModeType, IGameMode> _gameModeFactory;

        public TToeApp(IFactory<GameModeType, IGameMode> gameModeFactory)
        {
            _gameModeFactory = gameModeFactory;
        }

        public void Initialize()
        {
        }

        public async UniTask StartGame()
        {
            IGameMode gameMode = _gameModeFactory.Create(GameModeType.UserVsAi);
            gameMode.Initialize();
            
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