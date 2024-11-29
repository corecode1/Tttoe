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
            Container.Bind<IAppView>().To<UiPanelMainMenu>().FromInstance(_uiWidgetsList.MainMenu).AsSingle();
        }
    }
}