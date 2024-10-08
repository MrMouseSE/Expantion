using UnityEngine;

namespace GlobalMap.Grid
{
    [CreateAssetMenu(menuName = "Descriptions/Create New Cell", fileName = "LocationCellDescription", order = 0)]
    public class GlobalMapCellDescription : ScriptableObject
    { 
        [SerializeField] private GlobalMapCellContainer _cellContainer;
        [Space]
        [SerializeField] private float _width = 1.28f;
        
        public GlobalMapCellContainer GlobalMapCellContainer => _cellContainer;
        public float Width => _width;
    }
}