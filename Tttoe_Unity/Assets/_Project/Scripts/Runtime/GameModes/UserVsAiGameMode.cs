using System.Collections.Generic;
using com.tttoe.runtime.Interfaces;
using Zenject;

namespace com.tttoe.runtime
{
    public class UserVsAiGameMode : GameModeBase, IUserVsAiGameMode
    {
        public UserVsAiGameMode(IFactory<PlayerType, TileOccupation, IPlayer> playerFactory, ISolver solver)
            : base(playerFactory, solver)
        {
        }

        protected override uint ExpectedPlayerCount => 2;
        protected override GameModeType Type { get; } = GameModeType.UserVsAi;

        protected override void FillPlayers(List<IPlayer> players)
        {
            players.Add(_playerFactory.Create(PlayerType.LocalUser, TileOccupation.X));
            players.Add(_playerFactory.Create(PlayerType.LocalAi, TileOccupation.O));
        }
    }
}