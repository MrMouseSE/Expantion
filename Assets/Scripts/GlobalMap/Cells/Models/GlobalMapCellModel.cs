using GlobalMap.Locations;
using UnityEngine;

namespace GlobalMap.Cells.Models
{
    public class GlobalMapCellModel
    {
        public GlobalMapCellDescription Description { get; }
        public IGlobalMapLocation Location { get; set; }
        public GlobalMapCellModelView View { get; }
        
        public GlobalMapCellModel(GlobalMapCellDescription description, Vector2 position, Transform root)
        {
            Description = description;
            View = new GlobalMapCellModelView(this);

            View.SetContainer(position, root);
        }
    }
}