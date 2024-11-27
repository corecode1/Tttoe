using com.tttoe.runtime.Interfaces;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime.Installers
{
    public class CommonInstaller : MonoInstaller<CommonInstaller>
    {
        [SerializeField] private Main _main;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BoardPresenter>().AsSingle();
            Container.BindInterfacesTo<Board>().AsSingle();
            Container.BindInterfacesTo<GameEvents>().AsSingle();
            Container.BindInterfacesTo<BoardSolver>().AsSingle();
            Container.BindInterfacesTo<NaiveAiMovesFinder>().AsSingle();
            Container.BindInterfacesTo<UserVsUserGameMode>().AsSingle();
            Container.BindInterfacesTo<UserVsAiGameMode>().AsSingle();
            Container.BindInterfacesTo<Main>().FromInstance(_main);
            
            Container.BindIFactory<TileOccupation, IUserControlledPlayer>().To<UserControlledPlayer>();
            Container.BindIFactory<TileOccupation, IAiControlledPlayer>().To<AiControlledPlayer>();
        }
    }
}