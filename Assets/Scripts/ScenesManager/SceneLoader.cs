using UnityEngine.SceneManagement;

namespace ScenesManager
{
    public static class SceneLoader
    {
        private static ScenesHandler _handler;
        
        private static void LoadScene(string scene, bool subscribeCollect)
        {
            SceneManager.LoadScene(scene,LoadSceneMode.Additive);
            if (!subscribeCollect) return;
            SceneManager.sceneLoaded += CollectControllers;
        }
        
        public static void LoadScenes(SceneHolder sceneHolder, ScenesHandler handler)
        {
            _handler = handler;
            for (var index = 0; index < sceneHolder.Scenes.Length; index++)
            {
                var scene = sceneHolder.Scenes[index];
                LoadScene(scene.SceneName,  index == sceneHolder.Scenes.Length-1);
            }
        }

        private static void CollectControllers(Scene loadedScene, LoadSceneMode loadSceneMode)
        {
            if (loadedScene.name != SceneManager.GetSceneAt(SceneManager.sceneCount-1).name) return;
            
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                var roots = scene.GetRootGameObjects();
                foreach (var rootObject in roots)
                {
                    if (rootObject.TryGetComponent(out SceneContainer controller))
                    {
                        _handler.AddSceneController(controller);
                    }
                }
            }
            
            _handler.SetActiveScene(GameConstants.DefaultSceneName);
            
            SceneManager.sceneLoaded -= CollectControllers;
        }
    }
}