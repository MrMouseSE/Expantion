using UnityEngine;

namespace GlobalMap.Grid
{
    public class GlobalMapCellModel
    {
        public GlobalMapCellDescription Description { get; }
        public GlobalMapCellModelView _view { get; }
        
        public GlobalMapCellModel(GlobalMapCellDescription description, Vector2 position, Transform root)
        {
            Description = description;
            _view = new GlobalMapCellModelView(this);

            _view.SetContainer(position, root);
        }
    }
}