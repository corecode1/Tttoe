using System;
using com.tttoe.runtime.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace com.tttoe.runtime
{
    public class MatchView : UiPanel, IMatchView
    {
        // TODO: timer, active player ui
        [SerializeField] private Button _revertButton;

        public event Action OnRevertRequested;

        public override void Initialize()
        {
            base.Initialize();
            _revertButton.onClick.AddListener(HandleRevertClicked);
        }

        public override void Dispose()
        {
            base.Dispose();
            _revertButton.onClick.RemoveListener(HandleRevertClicked);
        }

        private void HandleRevertClicked()
        {
            OnRevertRequested?.Invoke();
        }

        public void SetRevertAvailability(RevertAvailability availability)
        {
            _revertButton.gameObject.SetActive(availability != RevertAvailability.Unavailable);
            _revertButton.interactable = availability == RevertAvailability.Available;
        }
    }
}