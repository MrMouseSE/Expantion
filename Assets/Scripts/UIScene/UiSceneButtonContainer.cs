using System;
using ScenesManager;
using UnityEngine;
using UnityEngine.UI;

namespace UIScene
{
    public class UiSceneButtonContainer : MonoBehaviour
    {
        public Action<SceneType> ButtonPressedAction;
        public SceneType SceneType;
        public Button SceneButton;

        public void Awake()
        {
            SceneButton.onClick.AddListener(ButtonPressed);
        }

        private void ButtonPressed()
        {
            ButtonPressedAction.Invoke(SceneType);
        }

        private void OnDestroy()
        {
            SceneButton.onClick.RemoveAllListeners();
        }
    }
}