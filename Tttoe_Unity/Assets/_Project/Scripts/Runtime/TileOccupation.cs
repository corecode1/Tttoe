using System.Collections.Generic;
using System.Diagnostics;

namespace com.tttoe.runtime
{
    [DebuggerDisplay("{GetName()}")]
    public readonly struct TileOccupation
    {
        public static readonly TileOccupation NonOccupied = new(1);
        public static readonly TileOccupation Player1 = new(2);
        public static readonly TileOccupation Player2 = new(3);

        private static readonly Dictionary<int, string> NameLookup;

        private readonly int _value;

        static TileOccupation()
        {
            NameLookup = new Dictionary<int, string>()
            {
                {NonOccupied._value, nameof(NonOccupied)},
                {Player1._value, nameof(Player1)},
                {Player2._value, nameof(Player2)},
            };
        }

        private TileOccupation(int value)
        {
            _value = value;
        }

        // it's safe to overload only equality operators since we're not using TileOccupation struct in dictionaries or hashmaps
        public static bool operator ==(TileOccupation tile1, TileOccupation tile2)
        {
            return tile1._value == tile2._value;
        }

        public static bool operator !=(TileOccupation tile1, TileOccupation tile2)
        {
            return !(tile1 == tile2);
        }

        public string GetName()
        {
            return NameLookup[_value];
        }
    }
}