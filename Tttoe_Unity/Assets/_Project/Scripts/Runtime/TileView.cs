using UnityEngine;

namespace com.tttoe.runtime
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] GameObject _xImage;
        [SerializeField] GameObject _oImage;

        public void SetState(TileOccupation occupation)
        {
            _xImage.SetActive(occupation == TileOccupation.X);
            _oImage.SetActive(occupation == TileOccupation.O);
        }
    }
}