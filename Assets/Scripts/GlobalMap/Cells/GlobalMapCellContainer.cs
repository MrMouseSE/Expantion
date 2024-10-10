using UnityEngine;

namespace GlobalMap.Cells
{
    public class GlobalMapCellContainer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        public void SetSprite(Sprite sprite)
        {
            _renderer.sprite = sprite;
            _renderer.sortingOrder = (int)(100 - transform.position.y);
        }
    }
}