using Battle.BattleAction;
using Battle.BattleAction.BattleEvents;
using ScenesManager;
using Unit;

namespace Battle.BattleSceneScripts
{
    public class BattleSceneController : ISceneController
    {
        private BattleHeroButtonsHandler _battleHeroButtonsHandler;
        private BattleHolder _battleHolder;

        private BattleLoopHandler _battleLoopHandler;

        private BattleEventDescription _playerEvents;
        private BattleEventDescription _enemyEvents;
        private UnitClass _enemyUnit;
        private int _fightLoopCount;

        public void UpdateSceneData(ScenesDataHolder scenesData)
        {
            var uiController = scenesData.CurrentSceneUi as BattleSceneUiController;
            _battleHeroButtonsHandler = uiController.Handler;
            _battleHeroButtonsHandler.StartFightButtonPressed += StartFight;
            GenerateEnemyUnit(scenesData.CurrentEnemyLevel);

            _battleLoopHandler = uiController.LoopHandler;
        }

        public void Init(ScenesDataHolder scenesData)
        {
            throw new System.NotImplementedException();
            _fightLoopCount = GameConstants.BattleLoopCount;
        }

        private void GenerateEnemyUnit(int level)
        {
            _enemyUnit = UnitFactory.GenerateEnemy(level);
            _battleHeroButtonsHandler.EnemyTitle.text = _enemyUnit.Description.UnitName;
            _battleHeroButtonsHandler.EnemyPortrait.sprite = _enemyUnit.Description.UnitSprite;
        }

        private void StartFight(UnitClass playerUnit)
        {
            _battleHolder = new BattleHolder();
            _battleHolder.FillUnitsHolders(playerUnit, _playerEvents, _enemyUnit, _enemyEvents);
            BattleLoopController battleLoop = new BattleLoopController();
            battleLoop.Init(_battleLoopHandler, _battleHolder);
            battleLoop.FightCompleeteAction += ApplyFightResults;
        }

        private void ApplyFightResults(bool isPlayerWin, float damage)
        {
            var damagedUnit = isPlayerWin ? _battleHolder.Enemy.CurrentUnit : _battleHolder.Player.CurrentUnit;
            damagedUnit.Description.UnitCurrentHP -= damage;
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
