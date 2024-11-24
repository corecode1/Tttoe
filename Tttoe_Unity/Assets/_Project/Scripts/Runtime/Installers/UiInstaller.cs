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
            Container.Bind<IBoardView>().FromInstance(_uiWidgetsList.BoardView).AsSingle();
        }
    }
}