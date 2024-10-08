using System.Collections.Generic;
using GlobalMap.Grid;
using UnityEngine;

namespace GlobalMap
{
    [CreateAssetMenu(menuName = "Descriptions/Create New Location", fileName = "LocationDescription", order = 0)]
    public class GlobalMapDescription : ScriptableObject
    {
        [SerializeField] private GameObject _root;
        [Space]
        [SerializeField] private GlobalMapCellDescription _cell;
        [Space]
        [SerializeField] private int _radiusFactor;
        public GameObject Root => _root;
        public GlobalMapCellDescription Cell => _cell;
        public int RadiusFactor => _radiusFactor;
    }
}