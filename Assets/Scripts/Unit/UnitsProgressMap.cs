using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    [CreateAssetMenu(menuName = "Units Map", fileName = "UnitsProgressMap", order = 0)]
    public class UnitsProgressMap : ScriptableObject
    {
        public List<UnitDescriptionsHolder> Units;

        [Space]
        public List<EnemyUnitDescription> Enemies;
    }
}