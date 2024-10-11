using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GlobalMap.Cells
{
    [CreateAssetMenu(menuName = "Descriptions/Create Ground Preset", fileName = "GlobalMapCellGroundPresetDescription", order = 0)]
    public class GlobalMapCellGroundPresetDescription : ScriptableObject
    { 
        [SerializeField] private List<GlobalMapCellGroundPresetData> _groundPresets;
        
        public Sprite GetSpriteByWeight()
        {
            IList<GlobalMapCellGroundPresetData> presets = new List<GlobalMapCellGroundPresetData>();
            float totalSum = 0;

            foreach (var preset in _groundPresets)
            {
                presets.Add(preset);
                totalSum += preset.Weight;
            }
            
            float sum = 0;
            var randomProbability = Random.Range(0.0f, 1.0f);
            var count = presets.Count;

            for (var i = 0; i < count; i++)
            {
                var preset = presets[i];
                sum += preset.Weight;

                if (i == count - 1 || randomProbability <= sum / totalSum)
                {
                    return preset.Sprite;
                }
            }

            return _groundPresets.FirstOrDefault()?.Sprite;
        }
    }
}