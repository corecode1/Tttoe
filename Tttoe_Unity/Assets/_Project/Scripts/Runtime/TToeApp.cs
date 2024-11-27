using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class TToeApp : IInitializable
    {
        private IUserVsAiGameMode _gameMode;

        public TToeApp(IUserVsUserGameMode userMode, IUserVsAiGameMode aiMode)
        {
            _gameMode = aiMode;
        }

        public void Initialize()
        {
        }

        public async UniTask StartGame()
        {
            await _gameMode.StartGame();

            GameOverCheckResult result = GameOverCheckResult.None;

            while (result == GameOverCheckResult.None)
            {
                result = await _gameMode.MakeTurn();
            }

            Debug.Log($"Game over! result: {result}");
        }
    }
}