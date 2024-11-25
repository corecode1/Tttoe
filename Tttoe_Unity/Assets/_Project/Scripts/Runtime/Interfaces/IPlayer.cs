using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Zenject;

namespace com.tttoe.runtime.Interfaces
{
    public interface IPlayer : IInitializable, IDisposable
    {
        TileOccupation Occupation { get; }
        UniTask MakeTurn();
    }

    public interface IUserControlledPlayer : IPlayer
    {
    }
}