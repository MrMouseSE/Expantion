using System.Collections.Generic;
using UnityEngine;

namespace GlobalMap.Cells
{
    [CreateAssetMenu(menuName = "Descriptions/Create Ground Preset", fileName = "GlobalMapCellGroundPresetDescription", order = 0)]
    public class GlobalMapCellGroundPresetDescription : ScriptableObject
    { 
        [SerializeField] private List<Sprite> _spriteVariants;
        
        public List<Sprite> SpriteVariants => _spriteVariants;
    }
}