using System.Collections.Generic;
using Battle.BattleAction.BattleEvents;
using Unit;
using UnityEngine;

namespace Battle.BattleAction
{
    public class UnitHolder
    {
        public UnitClass CurrentUnit;
        public List<BattleEvent> FightEvents = new List<BattleEvent>();
        public BattleEventsController EventsController;
        
        public UnitHolder(UnitClass currentUnit, BattleEventDescription description)
        {
            CurrentUnit = currentUnit;
            EventsController = new BattleEventsController(description);
        }

        public void GenerateNewFightEvent()
        {
            EventsController.GenerateNewFightEvent();
        }

        public void SelectCurrentFightEvent()
        {
            FightEvents.Add(EventsController.GetFightEvent());
            EventsController.ClearFightEvent();
        }

        public int CalculateUnitValue()
        {
            float result = 0;
            result += CurrentUnit.Description.UnitCurrentValue;
            foreach (var fightEvent in FightEvents)
            {
                result += fightEvent.Value;
            }
            return Mathf.RoundToInt(result);
        }

        public int CalculateLerpValue(int value)
        {
            var floatValue = Mathf.Lerp(value, GameConstants.PerfectValue, CurrentUnit.Description.UnitCurrentValueCorrection);
            return Mathf.RoundToInt(floatValue);
        }
    }
}