using GlobalMap.Cells.Models;
using UnityEngine;

namespace GlobalMap.Locations
{
    public class GlobalMapLocation : IGlobalMapLocation
    {
        private readonly GlobalMapLocationDescription _description;

        public GlobalMapLocation(GlobalMapLocationDescription description)
        {
            _description = description;
        }

        public GlobalMapLocationDescription GetDescription() => _description;
        
        public void CreateView(GlobalMapCellModel cell)
        {
            cell.View.UpdateView(_description.SpriteVariants[Random.Range(0, _description.SpriteVariants.Count)]);
        }
    }
}