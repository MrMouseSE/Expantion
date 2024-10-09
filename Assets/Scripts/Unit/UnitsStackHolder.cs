using System;

namespace Unit
{
    public class UnitsStackHolder
    {
        public UnitClass[] StackUnits = new UnitClass[Enum.GetValues(typeof(UnitTypes)).Length];

        public void AddUnit(UnitClass unit)
        {
            StackUnits[(int)unit.UnitType] = unit;
        }

        public UnitClass GetUnit(UnitTypes type)
        {
            return StackUnits[(int)type];
        }
    }
}