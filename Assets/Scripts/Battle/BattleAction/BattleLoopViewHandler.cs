using System;
using Battle.BattleAction.BattleEvents;
using Battle.BattleSceneScripts;
using TMPro;
using Unit;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.BattleAction
{
    public class BattleLoopViewHandler : MonoBehaviour
    {
        public GameObject MyGameObject;
        public Action StartFightAction;
        public Button StartFightButton;

        public Action<bool> AddEventAction;
        public Button AddEventButton;
        
        public BattleEventDrawer PlayerBattleEventDrawer;
        
        public BattleEventDrawer EnemyBattleEventDrawer;

        public GameObject BattleResult;
        public TMP_Text ResultText;

        public BattleUnitViewHolder PlayerViewHolder;
        public BattleUnitViewHolder EnemyViewHolder;

        public void Init()
        {
            StartFightButton.onClick.AddListener(StartFight);
            AddEventButton.onClick.AddListener(AddEvent);
        }

        public void UpdateUnitInfo(UnitClass playerUnit, UnitClass enemyUnit)
        {
            PlayerViewHolder.UnitTitle.text = GetUnitTitleString(playerUnit);
            PlayerViewHolder.UnitScreen.sprite = playerUnit.Description.UnitSprite;
            PlayerViewHolder.ScreenTransform.localScale = Vector3.one*0.3f;
            EnemyViewHolder.UnitTitle.text = GetUnitTitleString(enemyUnit);
            EnemyViewHolder.UnitScreen.sprite = enemyUnit.Description.UnitSprite;
            EnemyViewHolder.ScreenTransform.localScale = Vector3.one*0.3f;
        }

        private string GetUnitTitleString(UnitClass unit)
        {
            return unit.Description.UnitName + " " + unit.Description.UnitCurrentHP + " hp";
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