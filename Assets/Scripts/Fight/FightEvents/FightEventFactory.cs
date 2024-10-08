using UnityEngine;

namespace Fight.FightEvents
{
    public static class FightEventFactory
    {
        public static FightEvent GenerateFightEvent(FightEventDescription description)
        {
            FightEvent fightEvent = new FightEvent();
            var holder = description.GetRandomEvent(100f);
            fightEvent.EventDescription = holder.EventDescription;
            fightEvent.Value = Random.Range(holder.ValueRange.x,holder.ValueRange.y);
            return fightEvent;
        }
    }
}
