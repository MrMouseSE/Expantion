using UnityEngine;

namespace GlobalMap.Cells
{
    [CreateAssetMenu(menuName = "Descriptions/Create New Cell", fileName = "GlobalMapCellDescription", order = 0)]
    public class GlobalMapCellDescription : ScriptableObject
    { 
        [SerializeField] private GlobalMapCellController _cellController;
        [Space]
        [SerializeField] private float _width = 1.28f;
        
        public GlobalMapCellController GlobalMapCellController => _cellController;
        public float Width => _width;
    }
}