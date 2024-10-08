using System.Collections.Generic;
using Fight.FightEvents;
using UnityEngine;

namespace Fight
{
    public class UnitHolder
    {
        public UnitClass CurrentUnit;
        public List<FightEvent> FightEvents = new List<FightEvent>();
        public FightEventsController EventsController;

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
        
        public UnitHolder(UnitClass currentUnit, FightEventDescription description)
        {
            CurrentUnit = currentUnit;
            EventsController = new FightEventsController(description);
        }
    }
}
