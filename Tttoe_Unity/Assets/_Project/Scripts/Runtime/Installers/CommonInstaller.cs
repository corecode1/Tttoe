using com.tttoe.runtime.Interfaces;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime.Installers
{
    public class CommonInstaller : MonoInstaller<CommonInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BoardPresenter>().AsSingle();
            Container.BindInterfacesTo<Board>().AsSingle();
            Container.BindInterfacesTo<GameEvents>().AsSingle();
            Container.BindInterfacesAndSelfTo<Player>().AsSingle();
            Container.BindFactory<TileOccupation, Player, Player.Factory>();
            Container.BindInterfacesAndSelfTo<GameMode>().AsSingle();
        }
    }
}