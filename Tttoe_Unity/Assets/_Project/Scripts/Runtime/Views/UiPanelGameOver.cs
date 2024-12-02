using TMPro;
using UnityEngine;

namespace com.tttoe.runtime
{
    public class UiPanelGameOver : UiPanel, IGameOverScreen
    {
        [SerializeField] private TextMeshProUGUI _infoText;

        public void ShowGameOverInfo(GameOverCheckResult result, TileOccupation winner)
        {
            var infoString = result == GameOverCheckResult.Win
                ? string.Format("Player '{0}' wins!", winner)
                : "Tie!";

            _infoText.text = infoString;
        }
    }
}