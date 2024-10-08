using System.Collections.Generic;

namespace ScenesManager
{
    public class ScenesHandler
    {
        private List<SceneContainer> _sceneControllers = new List<SceneContainer>();

        public void AddSceneController(SceneContainer sceneContainer)
        {
            _sceneControllers.Add(sceneContainer);
        }

        public void SetActiveScene(SceneType type)
        {
            foreach (var sceneController in _sceneControllers)
            {
                sceneController.SetCurrentState(sceneController.Type == type);
            }
        }
    }
}
