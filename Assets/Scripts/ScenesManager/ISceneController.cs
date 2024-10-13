namespace ScenesManager
{
    public interface ISceneController
    {
        public void UpdateSceneData(ScenesDataHolder sceneData);

        public void Init(ScenesDataHolder sceneData);
    }
}