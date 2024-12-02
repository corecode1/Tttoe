using com.tttoe.runtime.Interfaces;

namespace com.tttoe.runtime
{
    public class MatchModel : IMatchModel
    {
        public GameModeType GameModeType { get; }

        public MatchModel(GameModeType mode)
        {
            GameModeType = mode;
        }
    }
}