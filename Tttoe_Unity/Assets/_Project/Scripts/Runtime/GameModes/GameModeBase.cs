using System;
using System.Collections.Generic;
using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public abstract class GameModeBase : IGameMode
    {
        private readonly List<IPlayer> _players;
        private readonly ISolver _solver;

        private TileOccupation? _winner;
        private GameOverCheckResult _gameResult;
        protected readonly IFactory<PlayerType, TileOccupation, IPlayer> _playerFactory;

        protected abstract uint ExpectedPlayerCount { get; }
        public abstract GameModeType Type { get; }
        public IPlayer CurrentPlayer { get; private set; }
        public event Action<IPlayer> OnPlayerChanged;

        protected GameModeBase(IFactory<PlayerType, TileOccupation, IPlayer> playerFactory, ISolver solver)
        {
            _playerFactory = playerFactory;
            _solver = solver;

            // virtual member call in a constructor, but ok in our case
            // since inheritors are expected to just return constant value
            // that doesn't depend on anything run in a constructor
            _players = new List<IPlayer>((int) ExpectedPlayerCount);
        }

        protected abstract void FillPlayers(List<IPlayer> players);

        public UniTask StartGame()
        {
            _winner = null;
            return UniTask.CompletedTask;
        }

        public async UniTask<GameOverCheckResult> MakeTurn()
        {
            GameOverCheckResult result = GameOverCheckResult.None;

            if (_players.Count == 0)
            {
                throw new Exception("Game mode need to be initialized before making a turn");
            }

            for (var i = 0; i < _players.Count; i++)
            {
                CurrentPlayer = _players[i];
                OnPlayerChanged?.Invoke(CurrentPlayer);

                Debug.Log($"Player {CurrentPlayer.Occupation.GetChar()} Turn");
                await CurrentPlayer.MakeTurn();

                result = _solver.CheckForGameOver(out _winner);

                if (result != GameOverCheckResult.None)
                {
                    CurrentPlayer = null;
                    OnPlayerChanged?.Invoke(CurrentPlayer);
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