using System;
using GlobalMap.Grid;
using UnityEngine;

namespace GlobalMap
{
    public class GlobalMapContainer : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [Space]
        [SerializeField] private GlobalMapCellDescription _terrainCell;
        [SerializeField] private GlobalMapCellDescription _playerHomeCell;
        [Space]
        [SerializeField] private int _radiusFactor;
        public Transform Root => _root;
        public GlobalMapCellDescription PlayerHomeCell => _playerHomeCell;
        public GlobalMapCellDescription TerrainCell => _terrainCell;
        public int RadiusFactor => _radiusFactor;

        private void Awake()
        {
            var globalMapModelView = new GlobalMapModelView(this);
        }
    }
}