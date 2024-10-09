using UnityEngine;

namespace GlobalMap.Cells.Models
{
    public class GlobalMapCellModel
    {
        public GlobalMapCellDescription Description { get; }
        private GlobalMapCellModelView _view { get; }
        
        public GlobalMapCellModel(GlobalMapCellDescription description, Vector2 position, Transform root)
        {
            Description = description;
            _view = new GlobalMapCellModelView(this);

            _view.SetContainer(position, root);
        }
    }
}