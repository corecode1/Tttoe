using System;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public abstract class UiPanel : MonoBehaviour, IInitializable, IDisposable
    {
        public virtual void Activate(bool active)
        {
            gameObject.SetActive(active);
        }

        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
        }

        private void Awake()
        {
            Activate(false);
        }
    }
}