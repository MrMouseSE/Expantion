using System;
using Battle.BattleSceneScripts;
using City;
using GlobalMap;
using ScenesManager;
using UIScene;
using Unit;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GlobalMapGenerationDataHolder GenerationDataHolder;
    public UnitsProgressMap UnitsMap;
    
    public static ScenesDataHolder CurrentScenesDataHolder;
    private static ScenesHandler _scenesHandler;
    private static readonly ISceneController[] SceneControllers = 
        new ISceneController[Enum.GetValues(typeof(SceneType)).Length];

    public void Awake()
    {
        UnitFactory.Map = UnitsMap;
        
        CurrentScenesDataHolder = new ScenesDataHolder();
        _scenesHandler = new ScenesHandler();
        SceneLoader.LoadScenes(_scenesHandler);
        SceneLoader.ScenesLoaded += OnScenesLoaded;

    }

    public static void SwitchScene(SceneType sceneType)
    {
        _scenesHandler.SetActiveScene(sceneType);
        SceneControllers[(int)sceneType-1].UpdateSceneData(CurrentScenesDataHolder);
    }

    private void OnScenesLoaded()
    {
        SceneLoader.ScenesLoaded -= OnScenesLoaded;
        CreateSceneControllers();
        FillGlobalMapData();
        
        SwitchScene(SceneType.Ui);
    }

    private void FillGlobalMapData()
    {
        GlobalMapSceneData globalMapSceneData = GenerationDataHolder.GetGenerationData();
        globalMapSceneData.SceneRoot = 
            _scenesHandler.GetSceneContainerByType(SceneType.GlobalMap).RootObject.transform;
        SceneControllers[2].Init(globalMapSceneData);
    }

    private void CreateSceneControllers()
    {
        SceneControllers[0] = new BattleSceneController();
        SceneControllers[1] = new CitySceneController();
        SceneControllers[2] = new GlobalMapSceneController();
        SceneControllers[3] = new UiSceneController();
    }
}