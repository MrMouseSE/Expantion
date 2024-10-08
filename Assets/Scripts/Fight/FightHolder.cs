using Fight.FightEvents;

namespace Fight
{
    public class FightHolder
    {
        public UnitHolder Enemy;
        public UnitHolder Player;

        public void FillUnitsHolders(UnitClass playerUnit, FightEventDescription playerEvents,
            UnitClass enemyUnit, FightEventDescription enemyEvents)
        {
            Player = new UnitHolder(playerUnit,playerEvents);
            Enemy = new UnitHolder(enemyUnit,enemyEvents);
        }
    }
}
