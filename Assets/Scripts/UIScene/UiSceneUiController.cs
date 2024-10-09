using System;
using UnityEngine.UI;

namespace UIScene
{
    public class UiSceneUiController : AbstractUiController
    {
        public Action StartBattleAction;
        
        public Button StartBattleButton;

        private void Start()
        {
            StartBattleButton.onClick.AddListener(StartBattle);
        }

        private void StartBattle()
        {
            StartBattleAction.Invoke();
        }

        private void OnDestroy()
        {
            StartBattleButton.onClick.RemoveAllListeners();
        }
    }
}
