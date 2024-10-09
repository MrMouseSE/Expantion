using System;
using UnityEngine.SceneManagement;

namespace ScenesManager
{
    public static class SceneLoader
    {
        public static Action ScenesLoaded;
        private static ScenesHandler _handler;
        
        private static void LoadScene(string scene, bool subscribeCollect)
        {
            SceneManager.LoadScene(scene,LoadSceneMode.Additive);
            if (!subscribeCollect) return;
            SceneManager.sceneLoaded += CollectControllers;
        }
        
        public static void LoadScenes(ScenesHandler handler)
        {
            _handler = handler;
            int count = Enum.GetValues(typeof(SceneType)).Length;
            for (var index = 1; index < count; index++)
            {
                LoadScene(Enum.GetName(typeof(SceneType), index),  index == count-1);
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
            
            SceneManager.sceneLoaded -= CollectControllers;
            ScenesLoaded.Invoke();
        }
    }
}