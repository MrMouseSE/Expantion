using GlobalMap.Locations;

namespace GlobalMap.Cells.Models
{
    public interface IGlobalMapCell : ICell
    {
        public IGlobalMapLocation Location { get; set; }
        public GlobalMapCellModelView View { get; }
    }
}