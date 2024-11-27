using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;

namespace com.tttoe.runtime
{
    public class AiControlledPlayer : PlayerBase, IAiControlledPlayer
    {
        private readonly IMoveFinder _moveFinder;
        private readonly IConfig _config;

        public AiControlledPlayer(TileOccupation occupation, IGameEvents events, IMoveFinder moveFinder, IConfig config)
            : base(events, occupation)
        {
            _config = config;
            _moveFinder = moveFinder;
        }

        protected override PlayerType Type { get; } = PlayerType.LocalAi;

        protected override void HandleMoveStart(State oldState, State newState)
        {
            base.HandleMoveStart(oldState, newState);
            
            if (_moveFinder.TryFindMove(out BoardTilePosition? move))
            {
                TriggerMoveAfterDelay(move.Value);
            }
        }

        private async UniTask TriggerMoveAfterDelay(BoardTilePosition move)
        {
            await UniTask.Delay(_config.AiMovesDelayMs);
            _events.TriggerMove(move, Occupation);
            SignalMoveEnded();
        }
    }
}