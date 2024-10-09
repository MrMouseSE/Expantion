using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GlobalMap.Cells
{
    public class GlobalMapCellContainer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _baseVisuals;

        public void RandomizeVisual()
        {
            var i = Random.Range(0, _baseVisuals.Count);

            var currentSprite = _baseVisuals[i];
            currentSprite.SetActive(true);
            
            var spriteRenderer = currentSprite.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sortingOrder = (int)(100 - transform.position.y);
        }
    }
}