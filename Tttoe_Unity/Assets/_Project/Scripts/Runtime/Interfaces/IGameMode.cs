using Cysharp.Threading.Tasks;

namespace com.tttoe.runtime.Interfaces
{
    public interface IGameMode
    {
        public UniTask StartGame();
        public UniTask<GameOverCheckResult> MakeTurn();
    }
}