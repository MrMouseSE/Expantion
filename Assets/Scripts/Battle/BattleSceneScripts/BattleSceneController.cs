using Battle.BattleAction;
using Battle.BattleAction.BattleEvents;
using ScenesManager;
using Unit;

namespace Battle.BattleSceneScripts
{
    public class BattleSceneController : ISceneController
    {
        public BattleHeroButtonsHandler BattleHeroButtonsHandler;
        public BattleHolder BattleHolder;

        private BattleEventDescription _playerEvents;
        private BattleEventDescription _enemyEvents;
        private UnitClass _enemyUnit;

        public void UpdateSceneData(ScenesDataHolder scenesData)
        {
            var uiController = scenesData.CurrentSceneUi as BattleSceneUiController;
            BattleHeroButtonsHandler = uiController.Handler;
            BattleHeroButtonsHandler.StartFightButtonPressed += StartFight;
            GenerateEnemyUnit(scenesData.CurrentEnemyLevel);
        }

        public void Init(ISceneControllerData data)
        {
            throw new System.NotImplementedException();
        }

        private void GenerateEnemyUnit(int level)
        {
            _enemyUnit = UnitFactory.GenerateEnemy(level);
        }

        private void StartFight()
        {
            BattleHolder = new BattleHolder();
            var playerUnit = UnitFactory.GenerateUnit(BattleHeroButtonsHandler.GetSelectedType());
            BattleHolder.FillUnitsHolders(playerUnit, _playerEvents, _enemyUnit, _enemyEvents);
        }

        private void Destroy()
        {
            BattleHeroButtonsHandler.StartFightButtonPressed -= StartFight;
        }
    }
}
