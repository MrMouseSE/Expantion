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
            EventRectTransform.SetParent(root);
            EventRectTransform.localScale = Vector3.one;
            EventRectTransform.localPosition = Vector3.zero;
            EventRectTransform.localPosition += Vector3.right * offset;
            EventImage = EventGameObject.AddComponent<Image>();
            GameObject textGO = new GameObject
            {
                name = "textGO",
            };
            var textRect =textGO.AddComponent<RectTransform>();
            textRect.SetParent(EventRectTransform);
            textRect.localScale = Vector3.one;
            textRect.localPosition = Vector3.zero;
            textRect.localPosition += Vector3.right * offset;
            
            EventText = textGO.AddComponent<TextMeshProUGUI>();
            EventText.fontSize = 10f;
            EventImage.sprite = newEvent.EventSprite;
            EventText.text = newEvent.EventDescription;
            EventValue = newEvent.Value;
        }
    }
}