using UnityEngine;

namespace ScenesManager
{
    public class SceneContainer : MonoBehaviour
    {
        public GameObject RootObject;
        public AbstractUiController SceneCanvas;
        public SceneType Type;

        public void SetCurrentState(bool active)
        {
            RootObject.SetActive(active);
            if (active)
            {
                GameController.SceneControllers[(int)Type].UpdateSceneData(SceneCanvas);
            }
        }
    }
}
