using ScenesManager;

namespace UIScene
{
    public class UiSceneController : ISceneController
    {
        private UiSceneUiController SceneUiController;
        public void UpdateSceneData(ScenesDataHolder sceneData)
        {
            if (!SceneUiController)
            {
                SceneUiController = sceneData.CurrentSceneUi as UiSceneUiController;
                SceneUiController.StartBattleAction += StartSceneFromMainMenu;
            }
        }

        public void Init(ISceneControllerData data)
        {
            throw new System.NotImplementedException();
        }

        private void StartSceneFromMainMenu(SceneType type)
        {
            GameController.SwitchScene(type);
        }

        private void Destroy()
        {
            SceneUiController.StartBattleAction -= StartSceneFromMainMenu;
        }
    }
}
