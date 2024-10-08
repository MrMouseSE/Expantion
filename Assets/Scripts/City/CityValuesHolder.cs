using System.Collections.Generic;
using Unit;

namespace City
{
    public static class CityValuesHolder
    {
        public static List<CityBuilding> Buildings;

        public static int GetCurrentLevelByType(UnitTypes type)
        {
            var building = GetBuildingByType(type);
            return building.Level;
        }

        public static void UpCurrentLevelByType(UnitTypes type)
        {
            var building = GetBuildingByType(type);
            building.Level ++;
        }

        private static CityBuilding GetBuildingByType(UnitTypes type)
        {
            return Buildings.Find(x => x.Type == type);
        }
    }
}