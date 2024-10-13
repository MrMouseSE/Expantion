using Battle.BattleAction.BattleEvents;

namespace Unit
{
    public class UnitClass
    {
        public UnitTypes UnitType;
        public int UnitLevel;
        public UnitDescription Description;
        public BattleEventDescription EventDescription;

        public UnitClass(UnitTypes type)
        {
            UnitType = type;
        }
    }
}