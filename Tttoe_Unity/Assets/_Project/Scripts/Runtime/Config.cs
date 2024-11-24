using com.tttoe.runtime.Interfaces;
using UnityEngine;

namespace com.tttoe.runtime
{
    [CreateAssetMenu(fileName = "Config", menuName = "Tttoe/Config")]
    public class Config : ScriptableObject, IConfig
    {
        [field: SerializeField] public int BoardSize { get; private set; }
    }
}