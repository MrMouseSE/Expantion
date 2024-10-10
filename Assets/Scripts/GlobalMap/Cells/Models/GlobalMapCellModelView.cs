using UnityEngine;

namespace GlobalMap.Cells.Models
{
    public class GlobalMapCellModelView
    {
        
        private GlobalMapCellContainer _container;
        private readonly GlobalMapCellModel _model;
        
        public GlobalMapCellModelView(GlobalMapCellModel model)
        {
            _model = model;
        }
        
        public void SetContainer(Vector2 position, Transform root)
        {
            var globalMapCellController = Object.Instantiate(_model.Description.GlobalMapCellController, new Vector3(position.x, position.y), Quaternion.identity);
            globalMapCellController.transform.SetParent(root);
            globalMapCellController.Activate(_model);
            
            _container = globalMapCellController.CellContainer;
            _container.RandomizeVisual();
        }

        public GlobalMapCellContainer GetContainer() => _container;
    }
}