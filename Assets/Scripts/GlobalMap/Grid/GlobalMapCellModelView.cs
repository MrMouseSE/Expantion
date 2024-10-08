using UnityEngine;

namespace GlobalMap.Grid
{
    public class GlobalMapCellModelView
    {

        private readonly GlobalMapCellModel _model;
        private GlobalMapCellContainer _container;
        public GlobalMapCellModelView(GlobalMapCellModel model)
        {
            _model = model;
        }
        
        public void SetContainer(Vector2 position, Transform root)
        {
            var cellContainer = Object.Instantiate(_model.Description.GlobalMapCellContainer, new Vector3(position.x, position.y, 0), Quaternion.identity);
            
            cellContainer.transform.SetParent(root);
            _container = cellContainer;
            _container.RandomizeVisual(position);
        }

        public GlobalMapCellContainer GetContainer()
        {
            return _container;
        }
    }
}