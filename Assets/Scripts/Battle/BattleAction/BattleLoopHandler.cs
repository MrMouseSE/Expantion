using System;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.BattleAction
{
    public class BattleLoopHandler : MonoBehaviour
    {
        public Action StartFightAction;
        public Button StartFightButton;

        public void Init()
        {
            StartFightButton.onClick.AddListener(StartFight);
        }

        private void StartFight()
        {
            StartFightButton.onClick.RemoveAllListeners();
            StartFightAction.Invoke();
        }
    }
}