using System;
using GlobalMap.Cells;
using GlobalMap.Locations;
using UnityEngine;

namespace GlobalMap
{
    public class GlobalMapContainer : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [Space]
        [SerializeField] private GlobalMapCellDescription _terrainCell;
        [SerializeField] private GlobalMapLocationDescription _playerHome;
        [Space]
        [SerializeField] private GlobalMapLocationsPresetDescription _startLocations; 
        [Space]
        [SerializeField] private int _radiusFactor;
        [SerializeField] private int _locationsCount;
        
        public Transform Root => _root;
        public GlobalMapLocationDescription PlayerHome => _playerHome;
        public GlobalMapCellDescription TerrainCell => _terrainCell;
        public GlobalMapLocationsPresetDescription StartLocations => _startLocations;
        public int RadiusFactor => _radiusFactor;
        public int LocationsCount => _locationsCount;

        private void Awake()
        {
            var globalMapModelView = new GlobalMapModel(this);
        }
    }
}