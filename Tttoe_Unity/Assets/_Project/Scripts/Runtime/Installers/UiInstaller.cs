using com.tttoe.runtime.Interfaces;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime.Installers
{
    public class UiInstaller : MonoInstaller<UiInstaller>
    {
        [SerializeField] private UiWidgetsList _uiWidgetsList;

        public override void InstallBindings()
        {
            Container.Bind<IBoardView>().To<BoardView>().FromInstance(_uiWidgetsList.BoardView).AsSingle();
            Container.Bind<IStartScreen>().To<UiPanelMainMenu>().FromInstance(_uiWidgetsList.MainMenu).AsSingle();
            Container.Bind<IMatchView>().To<MatchView>().FromInstance(_uiWidgetsList.MatchView).AsSingle();
            Container.Bind<IGameOverScreen>().To<UiPanelGameOver>().FromInstance(_uiWidgetsList.GameOverView).AsSingle();
        }
    }
}