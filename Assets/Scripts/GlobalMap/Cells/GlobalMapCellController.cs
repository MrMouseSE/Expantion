using GlobalMap.Cells.Models;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GlobalMap.Cells
{
    public class GlobalMapCellController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GlobalMapCellContainer _container;

        public GlobalMapCellContainer CellContainer => _container;
        
        private GlobalMapCellModel _model;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Click on cell {_model.Location?.GetDescription().LocationType}");
        }

        public void Activate(GlobalMapCellModel model)
        {
            _model = model;
        }
    }
}