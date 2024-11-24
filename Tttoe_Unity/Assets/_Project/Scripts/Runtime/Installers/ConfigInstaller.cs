using com.tttoe.runtime.Interfaces;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime.Installers
{
    public class ConfigInstaller : MonoInstaller<ConfigInstaller>
    {
        [SerializeField] private Config _config;

        public override void InstallBindings()
        {
            Container.Bind<IConfig>().FromInstance(_config);            
        }
    }
}