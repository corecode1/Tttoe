using UnityEngine;
using Zenject;

namespace com.tttoe.runtime
{
    public class Main : MonoBehaviour
    {
        [Inject]
        public void Construct(BoardPresenter board)
        {
            
        }
    }
}