using System.Collections.Generic;
using GlobalMap.Grid;
using UnityEngine;
using UnityEngine.Serialization;

namespace GlobalMap
{
    [CreateAssetMenu(menuName = "Descriptions/Create New Location", fileName = "LocationDescription", order = 0)]
    public class GlobalMapDescription : ScriptableObject
    {
        [SerializeField] private GameObject _root;
        [FormerlySerializedAs("_cell")]
        [Space]
        [SerializeField] private GlobalMapCellDescription _terrainCell;
        [SerializeField] private GlobalMapCellDescription _playerHomeCell;
        [Space]
        [SerializeField] private int _radiusFactor;
        public GameObject Root => _root;
        public GlobalMapCellDescription PlayerHomeCell => _playerHomeCell;
        public GlobalMapCellDescription TerrainCell => _terrainCell;
        public int RadiusFactor => _radiusFactor;
    }
}