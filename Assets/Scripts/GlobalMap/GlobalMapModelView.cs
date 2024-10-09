using System.Collections.Generic;
using GlobalMap.Cells;
using GlobalMap.Cells.Models;
using UnityEngine;

namespace GlobalMap
{
    public class GlobalMapModelView
    {
        private const float _angle = Mathf.Deg2Rad * 60;

        private static readonly float _sqrtThree = Mathf.Sqrt(3);
        
        private readonly IList<GlobalMapCellModel> _cells = new List<GlobalMapCellModel>();
        private readonly GlobalMapSceneData _generationDataContainer;

        public GlobalMapModelView(GlobalMapSceneData generationDataContainer)
        {
            _generationDataContainer = generationDataContainer;
            
            GenerateCells();
        }
        
        private void GenerateCells()
        {
            var root = _generationDataContainer.SceneRoot;
            
            var cellDescription = _generationDataContainer.TerrainCell;
            
            _cells.Add(new GlobalMapCellModel(_generationDataContainer.PlayerHomeCell, Vector3.zero, root));

            for (var k = 1; k < _generationDataContainer.RadiusFactor + 1; k++)
            {
                for (var i = 0; i < 6 * k; i++)
                {
                    var recalculateAngleForStep = _angle * Mathf.Floor(i / k);

                    var position = new Vector2(Mathf.Cos(recalculateAngleForStep), Mathf.Sin(recalculateAngleForStep)) * _sqrtThree * cellDescription.Width / 2 * k;
                    var divisionAngle = recalculateAngleForStep + 2 * _angle;
                    position += i % k * _sqrtThree * cellDescription.Width / 2 * new Vector2(Mathf.Cos(divisionAngle), Mathf.Sin(divisionAngle));
                
                    _cells.Add(new GlobalMapCellModel(cellDescription, position, root));
                }
            }
        }
    }
}