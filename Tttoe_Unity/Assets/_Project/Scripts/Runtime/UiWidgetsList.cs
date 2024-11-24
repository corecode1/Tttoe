using com.tttoe.runtime.Interfaces;
using UnityEngine;
using Zenject;

namespace com.tttoe.runtime.Installers
{
    public class UiWidgetsList : MonoBehaviour
    {
        [field:SerializeField] public BoardView BoardView { get; private set; }
    }
}