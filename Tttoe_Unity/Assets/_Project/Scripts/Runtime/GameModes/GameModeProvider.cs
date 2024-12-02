using System.Collections.Generic;
using com.tttoe.runtime.Interfaces;
using Zenject;

namespace com.tttoe.runtime
{
    public class GameModeProvider : IGameModeProvider
    {
        private readonly IFactory<GameModeType, IGameMode> _factory;
        private readonly Dictionary<GameModeType, IGameMode> _cache;

        private const int ExpectedGameModeCount = 5;

        public GameModeProvider(IFactory<GameModeType, IGameMode> factory)
        {
            _factory = factory;
            _cache = new Dictionary<GameModeType, IGameMode>(ExpectedGameModeCount);
        }

        public IGameMode Get(GameModeType param)
        {
            if (_cache.TryGetValue(param, out IGameMode gameMode))
            {
                return gameMode;
            }

            gameMode = _factory.Create(param);
            gameMode.Initialize();
            _cache.Add(param, gameMode);
            return gameMode;
        }

        public void Dispose()
        {
            foreach (KeyValuePair<GameModeType,IGameMode> gameMode in _cache)
            {
                gameMode.Value.Dispose();
            }
        }
    }
}