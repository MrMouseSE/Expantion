using GlobalMap.Cells.Models;
using UnityEngine;

namespace GlobalMap.Cells
{
    public abstract class CellController : MonoBehaviour
    {
        public abstract GlobalMapCellContainer CellContainer { get; }
        
        public void Activate(ICell model)
        {
            OnActivate(model);
        }

        protected abstract void OnActivate(ICell model);
    }
}