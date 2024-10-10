using System.Collections.Generic;
using UnityEngine;

namespace GlobalMap.Locations
{
    [CreateAssetMenu(menuName = "Descriptions/Create New Locations Preset", fileName = "GlobalMapLocationsPresetDescription", order = 0)]
    public class GlobalMapLocationsPresetDescription : ScriptableObject
    {
        [SerializeField] private GlobalMapLocationDescription _homeLocation;
        [Space]
        [SerializeField] private List<GlobalMapLocationDescription> _locations;
        
        public GlobalMapLocationDescription HomeLocation => _homeLocation;
        public List<GlobalMapLocationDescription> Locations => _locations;
    }
}