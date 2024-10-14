using UnityEngine;

namespace GlobalMap.Cells.Models
{
    public interface ICell
    {
        public GlobalMapCellDescription Description { get; }
        public Vector2 Position { get; }
        public bool Occupied { get; }
    }
}