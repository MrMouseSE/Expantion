using UnityEngine;

namespace GlobalMap.Cells
{
    [CreateAssetMenu(menuName = "Descriptions/Create New Cell", fileName = "GlobalMapCellDescription", order = 0)]
    public class GlobalMapCellDescription : CellDescription
    { 
        [Space]
        [SerializeField] private GlobalMapCellController _cellController;
        
        public override CellController GlobalMapCellController => _cellController;
    }
    
    public abstract class CellDescription : ScriptableObject
    { 
        [SerializeField] private float _width = 1.28f;
        
        public abstract CellController GlobalMapCellController { get; }
        public float Width => _width;
    }
}