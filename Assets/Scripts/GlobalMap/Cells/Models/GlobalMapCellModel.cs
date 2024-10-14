using GlobalMap.Locations;
using GlobalMap.Presets;
using UnityEngine;

namespace GlobalMap.Cells.Models
{
    public class GlobalMapCellModel : IGlobalMapCell
    {
        public GlobalMapCellDescription Description { get; }
        public IGlobalMapLocation Location { get; set; }
        public GlobalMapCellModelView View { get; }
        public Vector2 Position { get; private set; }
        public bool Occupied => Location != null;

        public GlobalMapCellModel(GlobalMapCellDescription description, Vector2 position, Transform root, GlobalMapPresetData presetData)
        {
            Description = description;
            Position = position;

            View = new GlobalMapCellModelView(this, presetData);
            View.SetContainer(position, root);
        }
    }
}