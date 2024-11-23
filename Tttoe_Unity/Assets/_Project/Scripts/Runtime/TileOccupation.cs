using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace com.tttoe.runtime
{
    [DebuggerDisplay("{GetName()}")]
    public readonly struct TileOccupation : IEquatable<TileOccupation>
    {
        public static readonly TileOccupation NonOccupied = new(0);
        public static readonly TileOccupation Player1 = new(1);
        public static readonly TileOccupation Player2 = new(2);

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
        
        public string GetName()
        {
            return NameLookup[_value];
        }

        public static bool operator ==(TileOccupation tile1, TileOccupation tile2)
        {
            return tile1.Equals(tile2);
        }

        public static bool operator !=(TileOccupation tile1, TileOccupation tile2)
        {
            return !tile1.Equals(tile2);
        }
        
        public bool Equals(TileOccupation other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            return obj is TileOccupation other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value;
        }
    }
}