using System;
using System.Collections.Generic;
using com.tttoe.runtime.Interfaces;
using Zenject;

namespace com.tttoe.runtime
{
    public class UserVsUserGameMode : GameModeBase, IUserVsUserGameMode
    {
        public UserVsUserGameMode(IFactory<PlayerType, TileOccupation, IPlayer> playerFactory, ISolver solver)
            : base(playerFactory, solver)
        {
        }

        protected override uint ExpectedPlayerCount => 2;
        protected override GameModeType Type { get; } = GameModeType.UserVsUser;

        protected override void FillPlayers(List<IPlayer> players)
        {
            players.Add(_playerFactory.Create(PlayerType.LocalUser, TileOccupation.X));
            players.Add(_playerFactory.Create(PlayerType.LocalUser, TileOccupation.O));
        }
    }
}