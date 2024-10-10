using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GlobalMap.Cells.Models;
using GlobalMap.Locations;
using GlobalMap.Presets;
using UnityEngine;

namespace GlobalMap
{
    public class GlobalMapModel
    {
        private const float _angle = Mathf.Deg2Rad * 60;

        private static readonly float _sqrtThree = Mathf.Sqrt(3);
        
        private readonly Collection<GlobalMapCellModel> _cells = new ();
        private readonly Collection<GlobalMapLocation> _activeLocations = new ();
        private readonly GlobalMapSceneData _data;
        private readonly GlobalMapPresetData _currentPreset;

        public GlobalMapModel(GlobalMapSceneData data)
        {
            _data = data;
            _currentPreset = GetNewRandomGlobalMapPreset();
            
            GenerateCells();
            PopulateFromPreset(_currentPreset.LocationsPreset, _data.LocationsCount);
        }

        private GlobalMapPresetData GetNewRandomGlobalMapPreset()
        {
            return _data.GlobalMapPresetData.GlobalMapPresets[Random.Range(0, _data.GlobalMapPresetData.GlobalMapPresets.Count)];        
        }

        private void GenerateCells()
        {
            var root = _data.SceneRoot;
            
            var cellDescription = _data.GlobalMapCell;

            var homeCell = new GlobalMapCellModel(_data.GlobalMapCell, Vector3.zero, root, _currentPreset);
            _cells.Add(homeCell);
            CreateNewTargetLocationAtTargetCell(_currentPreset.LocationsPreset.HomeLocation, homeCell);

            for (var k = 1; k < _data.RadiusFactor + 1; k++)
            {
                for (var i = 0; i < 6 * k; i++)
                {
                    var recalculateAngleForStep = _angle * Mathf.Floor(i / k);

                    var position = new Vector2(Mathf.Cos(recalculateAngleForStep), Mathf.Sin(recalculateAngleForStep)) * _sqrtThree * cellDescription.Width / 2 * k;
                    var divisionAngle = recalculateAngleForStep + 2 * _angle;
                    position += i % k * _sqrtThree * cellDescription.Width / 2 * new Vector2(Mathf.Cos(divisionAngle), Mathf.Sin(divisionAngle));
                
                    _cells.Add(new GlobalMapCellModel(cellDescription, position, root, _currentPreset));
                }
            }
        }
        
        private bool GetEmptyCell(out GlobalMapCellModel cellModel)
        {
            var freeCells = _cells.Where(cell => !cell.Occupied).ToList();

            return GetEmptyCellOutOfFreeCells(out cellModel, freeCells);
        }
        
        private static bool GetEmptyCellOutOfFreeCells(out GlobalMapCellModel cellModel, IReadOnlyList<GlobalMapCellModel> freeCells)
        {
            if (freeCells.Count <= 0)
            {
                cellModel = null;
                return false;
            }

            var index = Random.Range(0, freeCells.Count);

            cellModel = freeCells[index];
            return true;
        }

        private void PopulateFromPreset(GlobalMapLocationsPresetDescription presetDescription, int count)
        {
            for (var i = 0; i < count; i++)
            {
                CreateNewLocationInRandomCell(presetDescription);
            }
        }

        private void CreateNewLocationInRandomCell(GlobalMapLocationsPresetDescription presetDescription)
        {
            if (!GetEmptyCell(out var targetCell)) return;
            
            var index = Random.Range(0, presetDescription.Locations.Count);
            var locationDescription = presetDescription.Locations[index];

            var locationModel = new GlobalMapLocation(locationDescription);
            
            targetCell.Location = locationModel;
            _activeLocations.Add(locationModel);
            
            locationModel.CreateView(targetCell);
        }
        
        private void CreateNewTargetLocationAtTargetCell(GlobalMapLocationDescription locationDescription, GlobalMapCellModel cell)
        {
            if (cell.Occupied) return;

            var locationModel = new GlobalMapLocation(locationDescription);
            
            cell.Location = locationModel;
            _activeLocations.Add(locationModel);
            
            locationModel.CreateView(cell);
        }
    }
}