using GlobalMap.Presets;
using UnityEngine;

namespace GlobalMap.Cells.Models
{
    public class GlobalMapCellModelView
    {
        private Sprite _defaultSprite;
        private GlobalMapCellContainer _container;
        private readonly GlobalMapCellModel _model;
        private readonly GlobalMapPresetData _presetData;

        public GlobalMapCellModelView(GlobalMapCellModel model, GlobalMapPresetData presetData)
        {
            _model = model;
            _presetData = presetData;
        }
        
        public void SetContainer(Vector2 position, Transform root)
        {
            var globalMapCellController = Object.Instantiate(_model.Description.GlobalMapCellController, new Vector3(position.x, position.y), Quaternion.identity);
            globalMapCellController.transform.SetParent(root);
            globalMapCellController.Activate(_model);
            
            _defaultSprite = _presetData.EnvironmentsPreset.GetSpriteByWeight();
            
            _container = globalMapCellController.CellContainer;
            _container.SetSprite(_defaultSprite);
        }

        public GlobalMapCellContainer GetContainer() => _container;
        public void UpdateView(Sprite sprite) => _container.SetSprite(sprite);
        public void ResetViewToDefault() => _container.SetSprite(_defaultSprite);
    }
}