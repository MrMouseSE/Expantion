
using GlobalMap.Cells.Models;
using UnityEngine;

namespace GlobalMap.Locations
{
    public class GlobalMapLocation : IGlobalMapLocation
    {
        private readonly GlobalMapLocationDescription _description;
        private GlobalMapLocationContainer _container;

        public GlobalMapLocation(GlobalMapLocationDescription description)
        {
            _description = description;
        }

        public GlobalMapLocationDescription GetDescription()
        {
            return _description;
        }
        
        public void CreateView(GlobalMapCellModel cell)
        {
            var newBuilding = Object.Instantiate(_description.Container, cell.View.GetContainer().transform);
            newBuilding.transform.localPosition = new Vector3(0f, 0f, 0f);
            
            _container = newBuilding;
            _container.SetSpriteLayerOrder(cell);
        }
    }
}