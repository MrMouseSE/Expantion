using Battle.BattleAction.BattleEvents;
using Unit;

namespace Battle.BattleAction
{
    public class BattleHolder
    {
        public UnitHolder Enemy;
        public UnitHolder Player;

        public void FillUnitsHolders(UnitClass playerUnit, UnitClass enemyUnit)
        {
            Player = new UnitHolder(playerUnit);
            Enemy = new UnitHolder(enemyUnit);
        }
    }
}
