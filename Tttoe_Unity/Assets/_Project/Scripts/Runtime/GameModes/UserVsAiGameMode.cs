using System.Collections.Generic;
using com.tttoe.runtime.Interfaces;
using Zenject;

namespace com.tttoe.runtime
{
    public class UserVsAiGameMode : GameModeBase, IUserVsAiGameMode
    {
        private readonly IFactory<TileOccupation, IUserControlledPlayer> _userPlayerFactory;
        private readonly IFactory<TileOccupation, IAiControlledPlayer> _aiPlayerFactory;

        public UserVsAiGameMode(
            ISolver solver,
            IFactory<TileOccupation, IUserControlledPlayer> userPlayerFactory,
            IFactory<TileOccupation, IAiControlledPlayer> aiPlayerFactory
        ) : base(solver)
        {
            _aiPlayerFactory = aiPlayerFactory;
            _userPlayerFactory = userPlayerFactory;
        }

        protected override uint ExpectedPlayerCount => 2;

        protected override void FillPlayers(List<IPlayer> players)
        {
            players.Add(_userPlayerFactory.Create(TileOccupation.X));
            players.Add(_aiPlayerFactory.Create(TileOccupation.O));
        }
    }
}