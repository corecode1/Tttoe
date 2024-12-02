using com.tttoe.runtime.Interfaces;
using UnityEngine;

namespace com.tttoe.runtime
{
    [CreateAssetMenu(fileName = "Config", menuName = "Tttoe/Config")]
    public class Config : ScriptableObject, IConfig
    {
        [field: SerializeField] public int BoardSize { get; private set; } = 3;
        [field: SerializeField] public int AiMovesDelayMs { get; private set; } = 500;
        [field: SerializeField] public uint InitialReverts { get; private set; } = 2;
        [field: SerializeField] public uint RevertsPerTurn { get; private set; } = 0;
        [field: SerializeField] public int RevertsDelayMs { get; private set; } = 500;
        [field: SerializeField] public bool ShowBoardOnGameOver { get; private set; } = true;
    }
}