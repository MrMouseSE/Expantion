using City;

namespace Unit
{
    public static class UnitFactory
    {
        public static UnitsProgressMap Map;

        public static UnitClass GenerateUnit(UnitTypes type)
        {
            UnitClass unit = new UnitClass(type);
            unit.UnitLevel = CityValuesHolder.GetCurrentLevelByType(type);
            unit.Description = GenerateUnitDescription(unit);
            return unit;
        }

        private static UnitDescription GenerateUnitDescription(UnitClass unit)
        {
            var bps = FindTypeFromMap(unit.UnitType, unit.UnitLevel);
            return SetupUnitValues(bps);
        }

        private static UnitDescriptionBlueprint[] FindTypeFromMap(UnitTypes type, int level)
        {
            var bph = Map.Units.Find(x => x.UnitsType == type);
            UnitDescriptionBlueprint[] bps = new UnitDescriptionBlueprint [level];
            for (int i = 0; i < level; i++)
            {
                bps[i] = bph.Blueprints[i];
            }

            return bps;
        }

        private static UnitDescription SetupUnitValues(UnitDescriptionBlueprint[] bps)
        {
            UnitDescription unit = new UnitDescription();
            foreach (var bp in bps)
            {
                unit.UnitCurrentDamage += bp.UnitAddDamage;
                unit.UnitCurrentHP += bp.UnitAddHP;
                unit.UnitCurrentValue += bp.UnitAddValue;
                unit.UnitCurrentValueCorrection += bp.UnitAddValueCorrection;
            }

            return unit;
        }
    }
}