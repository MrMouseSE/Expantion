using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Battle.BattleSceneScripts
{
    public class BattleHeroButtonsHandler : MonoBehaviour
    {
        public Action StartFightButtonPressed;
        
        public RectTransform MyRectTransform;
        public HeroButtonMono ButtonPrefab;
        public Button RerollButton;
        public Button StartBattleButton;
        
        public List<HeroButtonMono> HeroButtons = new List<HeroButtonMono>();
        
        private HeroButtonMono _selectedButton;

        public void Start()
        {
            GenerateButtons();
            RerollAllHeroes();
            RerollButton.onClick.AddListener(RerollAllHeroes);
            StartBattleButton.onClick.AddListener(StartBattle);
        }

        private void StartBattle()
        {
            if (!_selectedButton) return;
            StartFightButtonPressed.Invoke();
            StartBattleButton.enabled = false;
        }

        public void SelectedButton(HeroButtonMono selectedButton)
        {
            _selectedButton = selectedButton;
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
