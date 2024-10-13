using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle.BattleAction.BattleEvents
{
    [CreateAssetMenu(menuName = "Create FightEventDescription", fileName = "FightEventDescription", order = 0)]
    public class BattleEventDescription : ScriptableObject
    {
        public EventValuesHolder[] Events;

        public EventValuesHolder GetRandomEvent(float percent = 0f)
        {
            return Events[Random.Range(0, Events.Length)];
        }
    }

    [Serializable]
    public class EventValuesHolder
    {
        public Sprite EventSprite;
        public string EventDescription;
        public Vector2Int ValueRange;
    }
}
