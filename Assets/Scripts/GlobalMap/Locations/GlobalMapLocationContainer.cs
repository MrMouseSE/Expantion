using GlobalMap.Cells.Models;
using UnityEngine;

namespace GlobalMap.Locations
{
    public class GlobalMapLocationContainer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        
        public void SetSpriteLayerOrder(GlobalMapCellModel cellModel, Sprite sprite)
        {
            _renderer.sprite = sprite;
            _renderer.sortingOrder = (int)(100 - cellModel.View.GetContainer().transform.position.y);
        }
    }
}