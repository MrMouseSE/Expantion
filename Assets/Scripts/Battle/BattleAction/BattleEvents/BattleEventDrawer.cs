using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.BattleAction.BattleEvents
{
    public class BattleEventDrawer : MonoBehaviour
    {
        public RectTransform RootTransform;
        public List<EventHolder> CurrentEventsView = new List<EventHolder>();

        public void AddGeneratedEvent(BattleEvent newEvent)
        {
            int offset =  CurrentEventsView.Count;
            EventHolder newEventHolder = new EventHolder(newEvent, RootTransform, offset);
            CurrentEventsView.Add(newEventHolder);
        }

        public void ClearEvents()
        {
            foreach (var eventHolder in CurrentEventsView)
            {
                Destroy(eventHolder.EventGameObject);
            }
            CurrentEventsView.Clear();
        }
    }

    

}

