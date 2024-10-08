using City;
using FightSceneScripts;
using GlobalMapSceneScripts;
using ScenesManager;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private ScenesHandler _scenesHandler;
    
    public static ScenesDataHolder CurrentScenesDataHolder;
    private static readonly ISceneController[] SceneControllers = new ISceneController[3];

    public void Awake()
    {
        CurrentScenesDataHolder = new ScenesDataHolder();
        _scenesHandler = new ScenesHandler();
        SceneLoader.LoadScenes(_scenesHandler);
        CreateSceneControllers();
    }

    public void SwitchScene(SceneType sceneType, ScenesDataHolder scenesData)
    {
        SceneControllers[(int)sceneType].UpdateSceneData(scenesData);
        _scenesHandler.SetActiveScene(sceneType);
    }

    private void CreateSceneControllers()
    {
        SceneControllers[0] = new BattleSceneController();
        SceneControllers[1] = new CitySceneController();
        SceneControllers[2] = new GlobalMapSceneController();
    }
}
