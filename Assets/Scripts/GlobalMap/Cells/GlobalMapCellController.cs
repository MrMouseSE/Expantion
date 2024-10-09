using UnityEngine;
using UnityEngine.EventSystems;

namespace GlobalMap.Cells
{
    public class GlobalMapCellController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GlobalMapCellContainer _container;

        public GlobalMapCellContainer CellContainer => _container;
        
        private GlobalMapCellModelView _modelView;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Click on cell {_modelView.Position}");
        }

        public void Activate(GlobalMapCellModelView model)
        {
            _modelView = model;
        }
    }
}