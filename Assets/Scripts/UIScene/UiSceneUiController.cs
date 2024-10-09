using System;
using ScenesManager;

namespace UIScene
{
    public class UiSceneUiController : AbstractUiController
    {
        public Action<SceneType> StartBattleAction;
        
        public UiSceneButtonContainer[] UiButtons;

        private void Start()
        {
            foreach (var butt in UiButtons)
            {
                butt.ButtonPressedAction += LoadScene;
            }
        }

        private void LoadScene(SceneType type)
        {
            StartBattleAction.Invoke(type);
        }

        private void OnDestroy()
        {
            foreach (var butt in UiButtons)
            {
                butt.ButtonPressedAction -= LoadScene;
            }
        }
    }
}
