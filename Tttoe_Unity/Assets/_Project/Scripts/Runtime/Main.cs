using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class Main : MonoBehaviour, IInitializable
    {
        private IGameMode _gameMode;

        [Inject]
        public void Construct(IUserVsUserGameMode userMode, IUserVsAiGameMode aiMode)
        {
            _gameMode = aiMode;
        }

        public void Initialize()
        {
            StartGame();
        }

        async UniTaskVoid StartGame()
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