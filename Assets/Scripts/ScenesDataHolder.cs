using Battle.BattleAction.BattleEvents;
using ScenesManager;

public class ScenesDataHolder
{
    public AbstractUiController CurrentSceneUi;
    public BattleEventDescription CurrentBattlePlayerEventsDescription;
    public BattleEventDescription CurrentBattleEnemyEventsDescription;
    public ISceneControllerData CurrentSceneControllerData;
    public int CurrentEnemyLevel = 0;

}
