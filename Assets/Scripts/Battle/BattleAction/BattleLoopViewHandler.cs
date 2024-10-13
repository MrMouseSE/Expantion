using System;
using Battle.BattleAction.BattleEvents;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.BattleAction
{
    public class BattleLoopViewHandler : MonoBehaviour
    {
        public Action StartFightAction;
        public Button StartFightButton;

        public Action<bool> AddEventAction;
        public Button AddEventButton;
        
        public BattleEventDrawer PlayerBattleEventDrawer;
        
        public BattleEventDrawer EnemyBattleEventDrawer;

        public void Init()
        {
            StartFightButton.onClick.AddListener(StartFight);
            AddEventButton.onClick.AddListener(AddEvent);
        }

        private void AddEvent()
        {
            AddEventAction.Invoke(true);
        }

        private void StartFight()
        {
            AddEventButton.onClick.RemoveAllListeners();
            StartFightButton.onClick.RemoveAllListeners();
            StartFightAction.Invoke();
        }
    }
}