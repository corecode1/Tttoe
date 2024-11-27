using System;
using System.Collections.Generic;
using com.tttoe.runtime.Interfaces;
using Zenject;

namespace com.tttoe.runtime
{
    public class UserVsUserGameMode : GameModeBase, IUserVsUserGameMode
    {
        private readonly IFactory<TileOccupation, IUserControlledPlayer> _playerFactory;

        public UserVsUserGameMode(IFactory<TileOccupation, IUserControlledPlayer> playerFactory, ISolver solver)
            : base(solver)
        {
            _playerFactory = playerFactory;
        }

        protected override uint ExpectedPlayerCount => 2;

        protected override void FillPlayers(List<IPlayer> players)
        {
            players.Add(_playerFactory.Create(TileOccupation.X));
            players.Add(_playerFactory.Create(TileOccupation.O));
        }
    }
}