using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace com.tttoe.runtime
{
    [DebuggerDisplay("{GetName()}")]
    public readonly struct TileOccupation : IEquatable<TileOccupation>
    {
        public static readonly TileOccupation NonOccupied = new(default);
        public static readonly TileOccupation X = new('x');
        public static readonly TileOccupation O = new('o');
        public static readonly TileOccupation A = new('a');

        private static readonly Dictionary<char, string> NameLookup;

        private readonly char _value;

        static TileOccupation()
        {
            NameLookup = new Dictionary<char, string>()
            {
                {NonOccupied._value, nameof(NonOccupied)},
                {X._value, nameof(X)},
                {O._value, nameof(O)},
                {A._value, nameof(A)},
            };
        }

        public static TileOccupation FromChar(char value)
        {
            if (!NameLookup.ContainsKey(value))
            {
                string message = string.Format("Trying to get TileOccupation from invalid char: {0}", value);
                throw new ArgumentException(message);
            }

            return new TileOccupation(value);
        }

        private TileOccupation(char value)
        {
            _value = value;
        }

        public string GetName() => NameLookup[_value];
        
        public char GetChar() => _value;

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