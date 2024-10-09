using GlobalMap.Cells;
using GlobalMap.Locations;
using UnityEngine;

namespace GlobalMap
{
    [CreateAssetMenu(menuName = "Create GlobalMapGenerationDataHolder", fileName = "GlobalMapGenerationDataHolder", order = 0)]
    public class GlobalMapGenerationDataHolder : ScriptableObject
    {
        public GlobalMapCellDescription TerrainCell;
        [Space]
        public GlobalMapLocationsPresetDescription StartLocations;
        public GlobalMapLocationDescription PlayerHome;
        [Space]
        public int LocationsCount;
        [Space]
        public int RadiusFactor;

        public GlobalMapSceneData GetGenerationData()
        {
            var data = new GlobalMapSceneData
            {
                RadiusFactor = RadiusFactor,
                TerrainCell = TerrainCell,
                StartLocations = StartLocations,
                LocationsCount = LocationsCount,
                PlayerHome = PlayerHome
            };
            return data;
        }
    }
}
