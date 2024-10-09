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
            GlobalMapSceneData globalMapSceneData = data as GlobalMapSceneData;
            GlobalMapGenerationDataContainer container = new GlobalMapGenerationDataContainer();
            container.Root = globalMapSceneData.SceneRoot;
            container.RadiusFactor = globalMapSceneData.RadiusFactor;
            container.TerrainCell = globalMapSceneData.TerrainCell;
            container.PlayerHomeCell = globalMapSceneData.PlayerHomeCell;
            var globalMapModelView = new GlobalMapModelView(container);
        }
    }
}