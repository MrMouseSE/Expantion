using City;
using FightSceneScripts;
using GlobalMapSceneScripts;
using ScenesManager;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SceneHolder SceneHolder;
    
    private ScenesHandler _scenesHandler;

    public static ISceneController[] SceneControllers = new ISceneController[3];

    public void Start()
    {
        _scenesHandler = new ScenesHandler();
        SceneLoader.LoadScenes(SceneHolder, _scenesHandler);
        CreateSceneControllers();
    }

    public void SwitchScene(string name)
    {
        _scenesHandler.SetActiveScene(name);
    }

    private void CreateSceneControllers()
    {
        SceneControllers[0] = new FightSceneController();
        SceneControllers[1] = new CitySceneController();
        SceneControllers[2] = new GlobalMapSceneController();
    }
}
