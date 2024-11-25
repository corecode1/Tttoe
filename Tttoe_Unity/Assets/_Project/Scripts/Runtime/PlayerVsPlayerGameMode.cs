using System;
using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class PlayerVsPlayerGameMode : IGameMode, IInitializable, IDisposable
    {
        private readonly IPlayer[] _players;
        private readonly ISolver _solver;

        private TileOccupation? _winner;
        private GameOverCheckResult _gameResult;

        public PlayerVsPlayerGameMode(IFactory<TileOccupation, IUserControlledPlayer> playerFactory, ISolver solver)
        {
            IFactory<TileOccupation, IUserControlledPlayer> f = playerFactory;
            _solver = solver;
            _players = new IPlayer[]
            {
                playerFactory.Create(TileOccupation.X),
                playerFactory.Create(TileOccupation.O),
            };
        }

        public UniTask StartGame()
        {
            return UniTask.CompletedTask;
        }

        public async UniTask<GameOverCheckResult> MakeTurn()
        {
            GameOverCheckResult result = GameOverCheckResult.None;

            for (var i = 0; i < _players.Length; i++)
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