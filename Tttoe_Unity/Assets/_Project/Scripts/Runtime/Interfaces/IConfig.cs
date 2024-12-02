namespace com.tttoe.runtime.Interfaces
{
    public interface IConfig
    {
        public int BoardSize { get; }
        public int AiMovesDelayMs { get; }
        public uint InitialReverts { get; }
        public uint RevertsPerTurn { get; }
        public int RevertsDelayMs { get; }
        public bool ShowBoardOnGameOver { get; }
    }
}