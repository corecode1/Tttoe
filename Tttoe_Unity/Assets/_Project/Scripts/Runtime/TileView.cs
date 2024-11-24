using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.tttoe.runtime
{
    public class TileView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] GameObject _xImage;
        [SerializeField] GameObject _oImage;

        private BoardTilePosition _position;

        public event Action<BoardTilePosition> OnClicked;

        public void Init(BoardTilePosition position)
        {
            _position = position;
            SetState(TileOccupation.NonOccupied);
        }

        public void SetState(TileOccupation occupation)
        {
            _xImage.SetActive(occupation == TileOccupation.X);
            _oImage.SetActive(occupation == TileOccupation.O);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(_position);
        }
    }
}