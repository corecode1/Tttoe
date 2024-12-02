using com.tttoe.runtime.Interfaces;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class PlayerFactory : IFactory<PlayerType, TileOccupation, IPlayer>
    {
        private readonly DiContainer _container;

        public PlayerFactory(DiContainer container)
        {
            _container = container;
        }

        public IPlayer Create(PlayerType type, TileOccupation occupation)
        {
            IPlayer player;
            IGameEvents events = _container.Resolve<IGameEvents>();

            switch (type)
            {
                case PlayerType.LocalUser:
                    IBoard board = _container.Resolve<IBoard>();
                    player = new UserControlledPlayer(occupation, events, board);
                    break;
                case PlayerType.LocalAi:
                    player = CreateAiPlayer(occupation, events);
                    break;
                default:
                    Debug.LogError(string.Format("Unknown player type: {0}", type));
                    player = CreateAiPlayer(occupation, events);
                    break;
            }

            return player;
        }

        private AiControlledPlayer CreateAiPlayer(TileOccupation occupation, IGameEvents events)
        {
            return new AiControlledPlayer(
                occupation,
                events,
                _container.Resolve<IMoveFinder>(),
                _container.Resolve<IConfig>());
        }
    }
}