using System;
using TMPro;
using Unit;
using UnityEngine;
using UnityEngine.UI;

namespace FightSceneScripts
{
    public class HeroButtonMono : MonoBehaviour
    {
        public Action<HeroButtonMono> HeroButtPressed;
        
        public RectTransform MyRectTransform;
        public Button HeroButton;
        public Image ButtonImage;
        public Color UnselectedColor;
        public Color SelectedColor;
        public TMP_Text HeroLabel;
        [HideInInspector]
        public UnitTypes CurrentHeroType;

        private FightHeroButtonsHandler _heroButtonsHolder;

        public void Init(FightHeroButtonsHandler heroButtonsHolder)
        {
            HeroButton.onClick.AddListener(ButtPressed);
            _heroButtonsHolder = heroButtonsHolder;
            HeroButtPressed += _heroButtonsHolder.SelectedButton;
        }

        public void ButtPressed()
        {
            HeroButtPressed.Invoke(this);
        }

        public void SetHeroLabel(UnitTypes typeIndex)
        {
            string label = typeIndex.ToString();
            label = label.Remove(1, label.Length-1).ToUpper();
            HeroLabel.text = label;
        }

        public void SetState(bool isSelected)
        {
            ButtonImage.color = isSelected ? SelectedColor : UnselectedColor;
        }

        public void OnDestroy()
        {
            HeroButton.onClick.RemoveAllListeners();
            HeroButtPressed -= _heroButtonsHolder.SelectedButton;
        }
    }
}
