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
            EventRectTransform.localPosition += Vector3.right * offset * 70f;
            EventRectTransform.sizeDelta = new Vector2(300, 500);
            EventImage = EventGameObject.AddComponent<Image>();
            GameObject textGO = new GameObject
            {
                name = "textGO",
            };
            var textRect =textGO.AddComponent<RectTransform>();
            textRect.SetParent(EventRectTransform);
            textRect.anchorMin = new Vector2(0f, 0f);
            textRect.anchorMax = new Vector2(1f, 1f);
            textRect.pivot = new Vector2(0.5f,0.5f);
            textRect.localPosition = Vector3.zero;
            textRect.localScale = Vector3.one;
            
            EventText = textGO.AddComponent<TextMeshProUGUI>();
            EventText.alignment = TextAlignmentOptions.MidlineFlush;
            EventText.fontSize = 50f;
            EventImage.sprite = newEvent.EventSprite;
            EventText.text = newEvent.EventDescription;
            EventValue = newEvent.Value;
        }
    }
}