using GlobalMap.Cells.Models;
using UnityEngine;

namespace GlobalMap.Locations
{
    public class GlobalMapLocationContainer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        
        public void SetSpriteLayerOrder(GlobalMapCellModel cellModel)
        {
            _sprite.sortingOrder = (int)(100 - cellModel.View.GetContainer().transform.position.y);
        }
    }
}