using Battle.BattleAction;
using ScenesManager;
using Unit;

namespace Battle.BattleSceneScripts
{
    public class BattleSceneController : ISceneController
    {
        private BattleHeroButtonsHandler _battleHeroButtonsHandler;
        private BattleHolder _battleHolder;

        private BattleLoopViewHandler _battleLoopViewHandler;
        private BattleLoopController _battleLoop;
        
        private UnitClass _enemyUnit;
        private int _fightLoopCount;

        public void UpdateSceneData(ScenesDataHolder scenesData)
        {
            var uiController = scenesData.CurrentSceneUi as BattleSceneUiController;
            _battleHeroButtonsHandler = uiController.Handler;
            _battleHeroButtonsHandler.StartFightButtonPressed += StartFight;
            GenerateEnemyUnit(scenesData.CurrentEnemyLevel);

            _battleLoopViewHandler = uiController.LoopViewHandler;
            _battleLoopViewHandler.MyGameObject.SetActive(false);
        }

        public void Init(ScenesDataHolder scenesData)
        {
            _fightLoopCount = GameConstants.BattleLoopCount;
        }

        private void GenerateEnemyUnit(int level)
        {
            _enemyUnit = UnitFactory.GenerateEnemy(level);
            _battleHeroButtonsHandler.UpdateEnemyUnitInfo(_enemyUnit.Description);
        }

        private void StartFight(UnitClass playerUnit)
        {
            _battleHeroButtonsHandler.MyGameObject.SetActive(false);
            _battleLoopViewHandler.MyGameObject.SetActive(true);
            _battleLoopViewHandler.BattleResult.SetActive(false);
            _battleHolder = new BattleHolder();
            _battleHolder.FillUnitsHolders(playerUnit, _enemyUnit);
            _battleLoopViewHandler.UpdateUnitInfo(playerUnit,_enemyUnit);
            _battleLoop = new BattleLoopController();
            _battleLoop.Init(_battleLoopViewHandler, _battleHolder);
            _battleLoop.FightCompleeteAction += ApplyFightResults;
        }

        private void ApplyFightResults(bool isPlayerWin, float damage)
        {
            _battleLoop.FightCompleeteAction -= ApplyFightResults;
            _battleLoop = null;
            
            var damagedUnit = isPlayerWin ? _battleHolder.Enemy.CurrentUnit : _battleHolder.Player.CurrentUnit;
            damagedUnit.Description.UnitCurrentHP -= damage;

            _battleLoopViewHandler.BattleResult.SetActive(true);
            _battleLoopViewHandler.ResultText.text = damagedUnit.Description.UnitName + " get " + damage + " damage";
            
            _fightLoopCount -= 1;
            if (_fightLoopCount == 0)
            {
                
                GameController.SwitchScene(SceneType.GlobalMap);
            }
        }

        private void Destroy()
        {
            _battleHeroButtonsHandler.StartFightButtonPressed -= StartFight;
        }
    }
}
