using System.Collections.Generic;

namespace ScenesManager
{
    public class ScenesHandler
    {
        private List<SceneContainer> _sceneContainers = new List<SceneContainer>();

        public void AddSceneController(SceneContainer sceneContainer)
        {
            _sceneContainers.Add(sceneContainer);
        }

        public void SetActiveScene(SceneType type)
        {
            foreach (var sceneController in _sceneContainers)
            {
                sceneController.SetCurrentState(sceneController.Type == type);
            }
        }
    }
}
