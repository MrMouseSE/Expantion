using Fight.FightEvents;
using Unit;

namespace Fight
{
    public class BattleHolder
    {
        public UnitHolder Enemy;
        public UnitHolder Player;

        public void FillUnitsHolders(UnitClass playerUnit, BattleEventDescription playerEvents,
            UnitClass enemyUnit, BattleEventDescription enemyEvents)
        {
            Player = new UnitHolder(playerUnit,playerEvents);
            Enemy = new UnitHolder(enemyUnit,enemyEvents);
        }
    }
}
