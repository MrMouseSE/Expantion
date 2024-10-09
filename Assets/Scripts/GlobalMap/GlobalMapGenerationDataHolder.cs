using GlobalMap.Cells;
using UnityEngine;

namespace GlobalMap
{
    [CreateAssetMenu(menuName = "Create GlobalMapGenerationDataHolder", fileName = "GlobalMapGenerationDataHolder", order = 0)]
    public class GlobalMapGenerationDataHolder : ScriptableObject
    {
        public GlobalMapCellDescription TerrainCell;
        public GlobalMapCellDescription PlayerHomeCell;
        [Space]
        public int RadiusFactor;

        public GlobalMapSceneData GetGenerationData()
        {
            GlobalMapSceneData data = new GlobalMapSceneData();
            data.RadiusFactor = RadiusFactor;
            data.TerrainCell = TerrainCell;
            data.PlayerHomeCell = PlayerHomeCell;
            return data;
        }
    }
}
