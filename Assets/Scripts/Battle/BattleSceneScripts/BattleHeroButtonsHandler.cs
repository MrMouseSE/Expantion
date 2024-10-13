using System;
using System.Collections.Generic;
using TMPro;
using Unit;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Battle.BattleSceneScripts
{
    public class BattleHeroButtonsHandler : MonoBehaviour
    {
        public GameObject MyGameObject;
        public Action<UnitClass> StartFightButtonPressed;
        
        public RectTransform MyRectTransform;
        public HeroButtonMono ButtonPrefab;
        public Button RerollButton;
        public Button StartBattleButton;

        public TMP_Text HeroTitle;
        public Image HeroPortrait;

        public TMP_Text EnemyTitle;
        public Image EnemyPortrait;
        
        public List<HeroButtonMono> HeroButtons = new List<HeroButtonMono>();
        
        private HeroButtonMono _selectedButton;
        private UnitClass _selectedUnit;

        public void Start()
        {
            GenerateButtons();
            RerollAllHeroes();
            RerollButton.onClick.AddListener(RerollAllHeroes);
            StartBattleButton.onClick.AddListener(StartBattle);
        }

        private void StartBattle()
        {
            if (_selectedUnit == null) return;
            StartFightButtonPressed.Invoke(_selectedUnit);
            StartBattleButton.enabled = false;
        }

        public void SelectedButton(HeroButtonMono selectedButton)
        {
            if (selectedButton == _selectedButton) return;
            _selectedButton = selectedButton;
            _selectedUnit =  UnitFactory.GenerateUnit(_selectedButton.CurrentHeroType);
            HeroTitle.text = _selectedUnit.Description.UnitName;
            HeroPortrait.sprite = _selectedUnit.Description.UnitSprite;
            ResetSelectedButton();
        }

        public UnitTypes GetSelectedType()
        {
            return _selectedButton.CurrentHeroType;
        }

        private void GenerateButtons()
        {
            for (int i = 0; i < GameConstants.BattleHeroCountToChoise; i++)
            {
                var butt = Instantiate(ButtonPrefab, MyRectTransform, true);
                butt.MyRectTransform.localScale = Vector3.one;
                var position = MyRectTransform.position;
                position.x += 20 + 10 * i;
                butt.MyRectTransform.position = position;
                butt.Init(this);
                HeroButtons.Add(butt);
            }
        }
        
        private void RerollAllHeroes()
        {
            for (int i = 0; i < HeroButtons.Count; i++)
            {
                RerollHeroType(i);
            }
            UnselectButtons();
        }

        private void RerollHeroType(int heroIndex)
        {
            var index = (UnitTypes)Random.Range(0, Enum.GetValues(typeof(UnitTypes)).Length);
            HeroButtons[heroIndex].SetHeroLabel(index);
        }

        private void UnselectButtons()
        {
            _selectedButton = null;
            _selectedUnit = null;
            ResetSelectedButton();
        }

        private void ResetSelectedButton()
        {
            foreach (var heroButt in HeroButtons)
            {
                heroButt.SetState(heroButt == _selectedButton);
            }
        }

        private void OnDestroy()
        {
            RerollButton.onClick.RemoveAllListeners();
            StartBattleButton.onClick.RemoveAllListeners();
        }
    }
}
