using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace com.tttoe.runtime.Interfaces
{
    public interface IGameMode : IInitializable, IDisposable
    {
        public GameModeType Type { get; }
        public IPlayer CurrentPlayer { get; }
        public event Action<IPlayer> OnPlayerChanged;
        public UniTask StartGame();
        public UniTask<GameOverCheckResult> MakeTurn();
        public TileOccupation? GetWinner();
    }

    public interface IUserVsUserGameMode : IGameMode
    {
    }

    public interface IUserVsAiGameMode : IGameMode
    {
    }

    public interface IGameModeProvider : IProvider<GameModeType, IGameMode>, IDisposable
    {
    }
}