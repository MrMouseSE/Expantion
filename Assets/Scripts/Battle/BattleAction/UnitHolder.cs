using System.Collections.Generic;
using Battle.BattleAction.BattleEvents;
using Unit;
using UnityEngine;

namespace Battle.BattleAction
{
    public class UnitHolder
    {
        public UnitClass CurrentUnit;
        public List<BattleEvent> CurrentEvents = new List<BattleEvent>();
        public BattleEventsController EventsController;
        
        public UnitHolder(UnitClass currentUnit)
        {
            CurrentUnit = currentUnit;
            EventsController = new BattleEventsController(currentUnit.EventDescription);
        }

        public BattleEvent GenerateNewFightEvent()
        {
            var newEvent = EventsController.GenerateNewFightEvent();
            CurrentEvents.Add(newEvent);
            return newEvent;
        }

        public void ClearEvents()
        {
            CurrentEvents.Clear();
        }

        private int CalculateUnitValue()
        {
            float result = 0;
            result += CurrentUnit.Description.UnitCurrentValue;
            foreach (var fightEvent in CurrentEvents)
            {
                result += fightEvent.Value;
            }
            return Mathf.RoundToInt(result);
        }

        public int CalculateLerpValue()
        {
            var value = CalculateUnitValue();
            var floatValue = Mathf.Lerp(value, GameConstants.PerfectValue, CurrentUnit.Description.UnitCurrentValueCorrection);
            return Mathf.RoundToInt(floatValue);
        }
    }
}