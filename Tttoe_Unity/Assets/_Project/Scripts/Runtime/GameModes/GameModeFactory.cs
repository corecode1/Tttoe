using com.tttoe.runtime.Interfaces;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class GameModeFactory : IFactory<GameModeType, IGameMode>
    {
        private DiContainer _container;

        public GameModeFactory(DiContainer container)
        {
            _container = container;
        }

        public IGameMode Create(GameModeType type)
        {
            var factory = _container.Resolve<IFactory<PlayerType, TileOccupation, IPlayer>>();
            var solver = _container.Resolve<ISolver>();

            switch (type)
            {
                case GameModeType.UserVsUser:
                    return new UserVsUserGameMode(factory, solver);
                case GameModeType.UserVsAi:
                    return new UserVsAiGameMode(factory, solver);
                default:
                    Debug.LogError(string.Format("Unknown GameMode type: {0}", type));
                    return new UserVsUserGameMode(factory, solver);
            }
        }
    }
}