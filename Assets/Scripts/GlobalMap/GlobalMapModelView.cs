using System.Collections.Generic;
using GlobalMap.Grid;
using UnityEngine;

namespace GlobalMap
{
    public class GlobalMapModelView
    {
        private const float _angle = Mathf.Deg2Rad * 60;

        private static readonly float _sqrtThree = Mathf.Sqrt(3);
        
        private readonly IList<GlobalMapCellModel> _cells = new List<GlobalMapCellModel>();
        private readonly GlobalMapDescription _description;

        public GlobalMapModelView(GlobalMapDescription description)
        {
            _description = description;
            
            GenerateCells();
        }
        private Transform SetLocationRootTransform()
        {
            var root = Object.Instantiate(_description.Root);
            return root.transform;
        }
        
        private void GenerateCells()
        {
            var root = SetLocationRootTransform();
            
            var cellDescription = _description.Cell;
            
            _cells.Add(new GlobalMapCellModel(cellDescription, Vector3.zero, root));

            for (var k = 1; k < _description.RadiusFactor + 1; k++)
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