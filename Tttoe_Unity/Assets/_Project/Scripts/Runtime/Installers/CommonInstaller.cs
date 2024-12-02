using com.tttoe.runtime.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace com.tttoe.runtime.Installers
{
    public class CommonInstaller : MonoInstaller<CommonInstaller>
    {
        [SerializeField] private TToeAppSceneRoot _toeAppSceneRoot;

        public override void InstallBindings()
        {
            Container.Bind<BoardPresenter>().AsSingle();
            Container.Bind<MatchPresenter>().AsSingle();
            Container.BindInterfacesTo<TToeAppSceneRoot>().FromInstance(_toeAppSceneRoot);

            Container.Bind<IBoard>().To<Board>().AsSingle();
            Container.Bind<IGameEvents>().To<GameEvents>().AsSingle();
            Container.Bind<ISolver>().To<BoardSolver>().AsSingle();
            Container.Bind<IMoveFinder>().To<NaiveAiMovesFinder>().AsSingle();
            Container.Bind<IUserVsUserGameMode>().To<UserVsUserGameMode>().AsSingle();
            Container.Bind<IUserVsAiGameMode>().To<UserVsAiGameMode>().AsSingle();
            Container.Bind<TToeApp>().AsSingle();

            Container.BindInterfacesTo<PlayerFactory>().AsSingle();
            Container.BindInterfacesTo<GameModeFactory>().AsSingle();
            Container.BindInterfacesTo<GameModeProvider>().AsSingle();
            Container.BindIFactory<GameModeType, IMatchModel>().To<MatchModel>().AsSingle();
        }
    }
}