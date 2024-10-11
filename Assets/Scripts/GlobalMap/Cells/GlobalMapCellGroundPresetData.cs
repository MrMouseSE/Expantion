using System;
using UnityEngine;

namespace GlobalMap.Cells
{
    [Serializable]
    public class GlobalMapCellGroundPresetData
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _weight;

        public Sprite Sprite => _sprite;
        public float Weight => _weight;
    }
}