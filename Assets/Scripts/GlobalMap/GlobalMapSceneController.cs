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

        public void Init(ScenesDataHolder sceneData)
        {
            GlobalMapSceneData data = sceneData.CurrentSceneControllerData as GlobalMapSceneData;
            _globalMapModelView = new GlobalMapModel(data);
        }
    }
}