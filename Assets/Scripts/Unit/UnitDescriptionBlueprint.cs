using UnityEngine;

namespace Unit
{
    [CreateAssetMenu(menuName = "Create UnitDescriptionBlueprint", fileName = "UnitDescriptionBlueprint", order = 0)]
    public class UnitDescriptionBlueprint : ScriptableObject
    {
        public int UnitLevel;
        public float UnitAddDamage;
        public float UnitAddHP;
        public float UnitAddValue;
        public float UnitAddValueCorrection;
    }
}