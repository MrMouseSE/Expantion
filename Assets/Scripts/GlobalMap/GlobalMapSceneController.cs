using ScenesManager;

namespace GlobalMap
{
    public class GlobalMapSceneController : ISceneController
    {
        public void UpdateSceneData(ScenesDataHolder sceneData)
        {
            throw new System.NotImplementedException();
        }

        public void Init(ISceneControllerData data)
        {
            var globalMapModelView = new GlobalMapModelView(data.GetSceneData() as GlobalMapSceneData);
        }
    }
}