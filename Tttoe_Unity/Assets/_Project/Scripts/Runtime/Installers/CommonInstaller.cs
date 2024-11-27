using com.tttoe.runtime.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace com.tttoe.runtime.Installers
{
    public class CommonInstaller : MonoInstaller<CommonInstaller>
    {
        [FormerlySerializedAs("_main")] [SerializeField] private TToeAppSceneRoot _toeAppSceneRoot;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BoardPresenter>().AsSingle();
            Container.BindInterfacesTo<Board>().AsSingle();
            Container.BindInterfacesTo<GameEvents>().AsSingle();
            Container.BindInterfacesTo<BoardSolver>().AsSingle();
            Container.BindInterfacesTo<NaiveAiMovesFinder>().AsSingle();
            Container.BindInterfacesTo<UserVsUserGameMode>().AsSingle();
            Container.BindInterfacesTo<UserVsAiGameMode>().AsSingle();
            Container.Bind<TToeApp>().AsSingle();
            Container.BindInterfacesTo<TToeAppSceneRoot>().FromInstance(_toeAppSceneRoot);
            
            Container.BindIFactory<TileOccupation, IUserControlledPlayer>().To<UserControlledPlayer>();
            Container.BindIFactory<TileOccupation, IAiControlledPlayer>().To<AiControlledPlayer>();
        }
    }
}