using GlobalMap.Cells;
using GlobalMap.Presets;
using UnityEngine;

namespace GlobalMap
{
    [CreateAssetMenu(menuName = "Create GlobalMapGenerationDataHolder", fileName = "GlobalMapGenerationDataHolder", order = 0)]
    public class GlobalMapGenerationDataHolder : ScriptableObject
    {
        public GlobalMapCellDescription GlobalMapCell;
        [Space]
        public GlobalMapPresetDescription GlobalMapPresetData;
        [Space]
        public int LocationsCount;
        [Space]
        public int RadiusFactor;

        public GlobalMapSceneData GetGenerationData()
        {
            var data = new GlobalMapSceneData
            {
                RadiusFactor = RadiusFactor,
                GlobalMapCell = GlobalMapCell,
                GlobalMapPresetData = GlobalMapPresetData,
                LocationsCount = LocationsCount
            };
            return data;
        }
    }
}
