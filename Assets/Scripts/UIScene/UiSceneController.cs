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
                SceneUiController.StartBattleAction += StartBattleFromMainMenu;
            }
        }

        public void Init(ISceneControllerData data)
        {
            throw new System.NotImplementedException();
        }

        private void StartBattleFromMainMenu()
        {
            GameController.CurrentScenesDataHolder.CurrentEnemyLevel = 1;
            GameController.SwitchScene(SceneType.GlobalMap);
        }

        private void Destroy()
        {
            SceneUiController.StartBattleAction -= StartBattleFromMainMenu;
        }
    }
}
