using System;
using Battle.BattleSceneScripts;
using City;
using GlobalMapSceneScripts;
using ScenesManager;
using UIScene;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static ScenesDataHolder CurrentScenesDataHolder;
    private static ScenesHandler _scenesHandler;
    private static readonly ISceneController[] SceneControllers = new ISceneController[Enum.GetValues(typeof(SceneType)).Length];

    public void Awake()
    {
        CurrentScenesDataHolder = new ScenesDataHolder();
        _scenesHandler = new ScenesHandler();
        SceneLoader.LoadScenes(_scenesHandler);
        CreateSceneControllers();
    }

    public static void SwitchScene(SceneType sceneType)
    {
        _scenesHandler.SetActiveScene(sceneType);
        SceneControllers[(int)sceneType-1].UpdateSceneData(CurrentScenesDataHolder);
    }

    private void CreateSceneControllers()
    {
        SceneControllers[0] = new BattleSceneController();
        SceneControllers[1] = new CitySceneController();
        SceneControllers[2] = new GlobalMapSceneController();
        SceneControllers[3] = new UiSceneController();
    }
}