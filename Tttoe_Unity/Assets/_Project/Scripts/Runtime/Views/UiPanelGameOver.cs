using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.tttoe.runtime
{
    public class UiPanelGameOver : UiPanel, IGameOverScreen
    {
        [SerializeField] private TextMeshProUGUI _infoText;
        [SerializeField] private Button _playAgainButton;

        public event Action OnPlayAgain;

        public override void Initialize()
        {
            base.Initialize();
            _playAgainButton.onClick.AddListener(HandlePlayAgainClicked);
        }

        public override void Dispose()
        {
            base.Dispose();
            _playAgainButton.onClick.RemoveListener(HandlePlayAgainClicked);
        }

        private void HandlePlayAgainClicked()
        {
            OnPlayAgain?.Invoke();
        }

        public void ShowGameOverInfo(GameOverCheckResult result, TileOccupation winner)
        {
            var infoString = result == GameOverCheckResult.Win
                ? string.Format("Player '{0}' wins!", winner)
                : "Tie!";

            _infoText.text = infoString;
        }
    }
}