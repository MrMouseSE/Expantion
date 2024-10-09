using UnityEngine;

namespace GlobalMap.Locations
{
    [CreateAssetMenu(menuName = "Descriptions/Create New GM Location", fileName = "GlobalMapLocationDescription", order = 0)]
    public class GlobalMapLocationDescription : ScriptableObject
    {
        [SerializeField] private GlobalMapLocationType _locationType;
        [Space]
        [SerializeField] private GlobalMapLocationContainer _container;
        
        public GlobalMapLocationType LocationType => _locationType;
        public GlobalMapLocationContainer Container => _container;
    }
}