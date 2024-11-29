using System;
using UnityEngine;
using UnityEngine.UI;

namespace com.tttoe.runtime
{
    public class UiPanelMainMenu : UiPanel, IAppView
    {
        [SerializeField] private Button _userVsUserButton;
        [SerializeField] private Button _userVsAiButton;

        public event Action<GameModeType> OnGameModeSelected;

        public override void Initialize()
        {
            base.Initialize();
            
            _userVsUserButton.onClick.AddListener(HandleUserVsUserClicked);
            _userVsAiButton.onClick.AddListener(HandleUserVsAiClicked);
        }

        public override void Dispose()
        {
            _userVsUserButton.onClick.AddListener(HandleUserVsUserClicked);
            _userVsAiButton.onClick.AddListener(HandleUserVsAiClicked);
        }

        private void HandleUserVsUserClicked()
        {
            OnGameModeSelected?.Invoke(GameModeType.UserVsUser);
        }

        private void HandleUserVsAiClicked()
        {
            OnGameModeSelected?.Invoke(GameModeType.UserVsAi);
        }
    }
}