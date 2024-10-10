using GlobalMap.Cells;
using GlobalMap.Presets;
using ScenesManager;
using UnityEngine;

namespace GlobalMap
{
    public class GlobalMapSceneData : ISceneControllerData
    {
        public Transform SceneRoot;
        public GlobalMapCellDescription GlobalMapCell;
        public GlobalMapPresetDescription GlobalMapPresetData;
        
        public int LocationsCount;
        public int RadiusFactor;
        
        public ISceneControllerData GetSceneData() => this;
    }
}