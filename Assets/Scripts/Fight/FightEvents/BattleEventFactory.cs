using UnityEngine;

namespace Fight.FightEvents
{
    public static class BattleEventFactory
    {
        public static BattleEvent GenerateFightEvent(BattleEventDescription description)
        {
            BattleEvent battleEvent = new BattleEvent();
            var holder = description.GetRandomEvent(100f);
            battleEvent.EventDescription = holder.EventDescription;
            battleEvent.Value = Random.Range(holder.ValueRange.x,holder.ValueRange.y);
            return battleEvent;
        }
    }
}
