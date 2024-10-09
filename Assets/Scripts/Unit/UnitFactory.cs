using System.Linq;
using City;
using UnityEngine;

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

        public static UnitClass GenerateEnemy(int enemyLevel)
        {
            var enemyes = Map.Enemies.FindAll(x => x.UnitLevel == enemyLevel);
            var enemy = new UnitClass(0);
            enemy.Description = new UnitDescription();
            enemy.Description = SetupUnitValues(enemy.Description, enemyes[Random.Range(0, enemyes.Count)]);
            return enemy;
        }

        private static UnitDescription GenerateUnitDescription(UnitClass unit)
        {
            var bps = FindTypeFromMap(unit.UnitType, unit.UnitLevel);
            return SetupUnitValues(bps);
        }

        private static UnitDescriptionBlueprint[] FindTypeFromMap(UnitTypes type, int level)
        {
            var bph = Map.Units.Find(x => x.UnitsType == type);
            UnitDescriptionBlueprint[] bps = new UnitDescriptionBlueprint[level];
            for (int i = 0; i < level; i++)
            {
                bps[i] = bph.Blueprints[i];
            }

            return bps;
        }

        private static UnitDescription SetupUnitValues(UnitDescriptionBlueprint[] bps)
        {
            UnitDescription unit = new UnitDescription();
            return bps.Aggregate(unit, SetupUnitValues);
        }

        private static UnitDescription SetupUnitValues(UnitDescription unit, UnitDescriptionBlueprint bp)
        {
            unit.UnitName = bp.UnitName;
            unit.UnitSprite = bp.UniteSprite;
            unit.UnitCurrentDamage += bp.UnitAddDamage;
            unit.UnitCurrentHP += bp.UnitAddHP;
            unit.UnitCurrentValue += bp.UnitAddValue;
            unit.UnitCurrentValueCorrection += bp.UnitAddValueCorrection;
            return unit;
        }
    }
}