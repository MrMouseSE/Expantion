using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.BattleAction.BattleEvents
{
    [Serializable]
    public class EventHolder
    {
        public GameObject EventGameObject;
        public RectTransform EventRectTransform;
        public Image EventImage;
        public TMP_Text EventText;
        public int EventValue;

        public EventHolder(BattleEvent newEvent, RectTransform root, int offset)
        {
            EventGameObject = new GameObject("EventHolder");
            EventRectTransform = EventGameObject.AddComponent<RectTransform>();
            EventRectTransform.parent = root;
            EventRectTransform.localPosition = Vector3.zero;
            EventRectTransform.localPosition += Vector3.right * offset;
            EventImage = EventGameObject.AddComponent<Image>();
            EventText = EventGameObject.AddComponent<TextMeshPro>();
            EventImage.sprite = newEvent.EventImage;
            EventText.text = newEvent.EventDescription;
            EventValue = newEvent.Value;
        }
    }
}