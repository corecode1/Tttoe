using System;
using System.Collections.Generic;
using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public abstract class GameModeBase : IGameMode, IInitializable, IDisposable
    {
        private readonly List<IPlayer> _players;
        private readonly ISolver _solver;

        private TileOccupation? _winner;
        private GameOverCheckResult _gameResult;
        protected IFactory<PlayerType, TileOccupation, IPlayer> _playerFactory;

        protected abstract uint ExpectedPlayerCount { get; }

        protected GameModeBase(IFactory<PlayerType, TileOccupation, IPlayer> playerFactory, ISolver solver)
        {
            _playerFactory = playerFactory;
            _solver = solver;

            // virtual member call in a constructor, but ok in our case
            // since inheritors are expected to just return constant value
            // that doesn't depend on anything run in a constructor
            _players = new List<IPlayer>((int)ExpectedPlayerCount);
        }

        protected abstract void FillPlayers(List<IPlayer> players);

        public UniTask StartGame()
        {
            return UniTask.CompletedTask;
        }

        public async UniTask<GameOverCheckResult> MakeTurn()
        {
            GameOverCheckResult result = GameOverCheckResult.None;

            for (var i = 0; i < _players.Count; i++)
            {
                IPlayer player = _players[i];
                Debug.Log($"Player {player.Occupation.GetChar()} Turn");
                await player.MakeTurn();

                result = _solver.CheckForGameOver(out _winner);

                if (result == GameOverCheckResult.Win)
                {
                    return result;
                }
            }

            return result;
        }

        public bool TryGetWinner(out TileOccupation? winner)
        {
            winner = _winner;
            return _winner.HasValue;
        }

        public void Initialize()
        {
            FillPlayers(_players);

            foreach (IPlayer player in _players)
            {
                player.Initialize();   
            }
        }

        public void Dispose()
        {
            foreach (IPlayer player in _players)
            {
                player.Dispose();   
            }
        }
    }
}