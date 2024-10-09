using GlobalMap.Cells;
using UnityEngine;

namespace GlobalMap
{
    public class GlobalMapGenerationDataContainer
    {
        public Transform Root;
        public GlobalMapCellDescription PlayerHomeCell;
        public GlobalMapCellDescription TerrainCell;
        public int RadiusFactor;
    }
}