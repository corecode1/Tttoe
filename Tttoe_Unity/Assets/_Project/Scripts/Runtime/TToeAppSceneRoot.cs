using com.tttoe.runtime.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class TToeAppSceneRoot : MonoBehaviour, IInitializable
    {
        private TToeApp _app;

        [Inject]
        public void Construct(TToeApp app)
        {
            _app = app;
        }
        
        public void Initialize()
        {
            _app.Initialize();
            _app.StartGame();
        }
    }
}