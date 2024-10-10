using System;
using GlobalMap.Cells;
using GlobalMap.Locations;
using UnityEngine;

namespace GlobalMap.Presets
{
    [Serializable]
    public class GlobalMapPresetData
    {
        [SerializeField] private GlobalMapLocationsPresetDescription LocationsPresetPreset;
        [SerializeField] private GlobalMapCellGroundPresetDescription _environmentsPreset;

        public GlobalMapLocationsPresetDescription LocationsPreset => LocationsPresetPreset;
        public GlobalMapCellGroundPresetDescription EnvironmentsPreset => _environmentsPreset;
    }
}