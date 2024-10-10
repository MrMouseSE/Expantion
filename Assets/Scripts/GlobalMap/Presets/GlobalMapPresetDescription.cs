using System.Collections.Generic;
using UnityEngine;

namespace GlobalMap.Presets
{
    [CreateAssetMenu(menuName = "Descriptions/Create New GM Preset", fileName = "GlobalMapPresetDescription", order = 0)]
    public class GlobalMapPresetDescription : ScriptableObject
    {
        public List<GlobalMapPresetData> GlobalMapPresets;
    }
}