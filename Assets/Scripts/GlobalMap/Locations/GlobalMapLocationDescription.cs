using System.Collections.Generic;
using UnityEngine;

namespace GlobalMap.Locations
{
    [CreateAssetMenu(menuName = "Descriptions/Create New GM Location", fileName = "GlobalMapLocationDescription", order = 0)]
    public class GlobalMapLocationDescription : ScriptableObject
    {
        [SerializeField] private GlobalMapLocationType _locationType;
        [Space]
        [SerializeField] private GlobalMapLocationContainer _container;
        [Space]
        [SerializeField] private List<Sprite> _spriteVariants;
        
        public GlobalMapLocationType LocationType => _locationType;
        public GlobalMapLocationContainer Container => _container;
        public List<Sprite> SpriteVariants => _spriteVariants;
    }
}