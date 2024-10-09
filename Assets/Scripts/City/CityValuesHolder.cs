using System;
using System.Collections.Generic;
using Unit;
using UnityEngine;

namespace City
{
    public static class CityValuesHolder
    {
        public static List<CityBuilding> Buildings;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void InitializeBuildings()
        {
            Buildings = new List<CityBuilding>();
            foreach (UnitTypes value in Enum.GetValues(typeof(UnitTypes)))
            {
                Buildings.Add(new CityBuilding { Type = value, Level = 1 });
            }
        }

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