using GlobalMap.Cells;
using GlobalMap.Locations;
using ScenesManager;
using UnityEngine;

namespace GlobalMap
{
    public class GlobalMapSceneData : ISceneControllerData
    {
        public Transform SceneRoot;
        public GlobalMapCellDescription TerrainCell;
        public GlobalMapLocationsPresetDescription StartLocations;
        public GlobalMapLocationDescription PlayerHome;
        public int LocationsCount;
        public int RadiusFactor;
        
        public ISceneControllerData GetSceneData() => this;
    }
}