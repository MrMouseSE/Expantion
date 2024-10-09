using GlobalMap.Cells;
using ScenesManager;
using UnityEngine;

namespace GlobalMap
{
    public class GlobalMapSceneData : ISceneControllerData
    {
        public Transform SceneRoot;
        public GlobalMapCellDescription TerrainCell;
        public GlobalMapCellDescription PlayerHomeCell;
        public int RadiusFactor;
        
        public ISceneControllerData GetSceneData()
        {
            return this;
        }
    }
}
