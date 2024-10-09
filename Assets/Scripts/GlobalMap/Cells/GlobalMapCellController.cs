using System;
using GlobalMap.Cells.Models;
using GlobalMap.Locations;
using ScenesManager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GlobalMap.Cells
{
    public class GlobalMapCellController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GlobalMapCellContainer _container;

        public GlobalMapCellContainer CellContainer => _container;
        
        private GlobalMapCellModel _model;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Click on cell {_model.Location?.GetDescription().LocationType}");
            
            if(_model.Location != null)
                SwitchScene(_model.Location.GetDescription().LocationType);
        }

        private static void SwitchScene(GlobalMapLocationType locationType)
        {
            switch (locationType)
            {
                case GlobalMapLocationType.Home:
                    GameController.SwitchScene(SceneType.City);
                    break;
                case GlobalMapLocationType.Enemy:
                    GameController.SwitchScene(SceneType.Battle);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(locationType), locationType, null);
            }
        }

        public void Activate(GlobalMapCellModel model)
        {
            _model = model;
        }
    }
}