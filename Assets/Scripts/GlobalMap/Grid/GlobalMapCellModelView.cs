using UnityEngine;

namespace GlobalMap.Grid
{
    public class GlobalMapCellModelView
    {
        public Vector2 Position { get; private set; }
        private GlobalMapCellContainer _container;

        private readonly GlobalMapCellModel _model;
        public GlobalMapCellModelView(GlobalMapCellModel model)
        {
            _model = model;
        }
        
        public void SetContainer(Vector2 position, Transform root)
        {
            var globalMapCellController = Object.Instantiate(_model.Description.GlobalMapCellController, new Vector3(position.x, position.y), Quaternion.identity);
            Position = position;
            globalMapCellController.transform.SetParent(root);
            globalMapCellController.Activate(this);
            
            _container = globalMapCellController.CellContainer;
            _container.RandomizeVisual();
        }

        public GlobalMapCellContainer GetContainer()
        {
            return _container;
        }
    }
}