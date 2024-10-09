using ScenesManager;

namespace GlobalMap
{
    public class GlobalMapSceneController : ISceneController
    {
        private GlobalMapModel _globalMapModelView;

        public void UpdateSceneData(ScenesDataHolder sceneData)
        {
            throw new System.NotImplementedException();
        }

        public void Init(ISceneControllerData data)
        {
            _globalMapModelView = new GlobalMapModel(data.GetSceneData() as GlobalMapSceneData);
        }
    }
}