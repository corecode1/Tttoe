using Cysharp.Threading.Tasks;
using Zenject;

namespace com.tttoe.runtime.Interfaces
{
    public interface IGameMode : IInitializable
    {
        public UniTask StartGame();
        public UniTask<GameOverCheckResult> MakeTurn();
    }
    
    public interface IUserVsUserGameMode : IGameMode
    {
    }
    
    public interface IUserVsAiGameMode : IGameMode
    {
    }
}