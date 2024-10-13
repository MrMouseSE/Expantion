using System;
using Unit;

namespace Battle.BattleAction
{
    public class BattleLoopController
    {
        public Action<bool,float> FightCompleeteAction;
        private BattleLoopViewHandler _currentLoopViewHandler;
        private BattleHolder _currentbattleHolder;

        public void Init(BattleLoopViewHandler battleLoopViewHandler, BattleHolder battleHolder)
        {
            _currentLoopViewHandler = battleLoopViewHandler;
            _currentLoopViewHandler.StartFightAction += StartEnemyEventGathering;
            _currentLoopViewHandler.AddEventAction += AddEvent;
            _currentbattleHolder = battleHolder;
        }

        private void AddEvent(bool isPlayerEvent)
        {
            if (isPlayerEvent)
            {
                var playerEvent = _currentbattleHolder.Player.GenerateNewFightEvent();
                _currentLoopViewHandler.PlayerBattleEventDrawer.AddGeneratedEvent(playerEvent);
            }
            else
            {
                var enemyEvent = _currentbattleHolder.Enemy.GenerateNewFightEvent();
                _currentLoopViewHandler.EnemyBattleEventDrawer.AddGeneratedEvent(enemyEvent);
            }
        }

        private void StartEnemyEventGathering()
        {
            while (_currentbattleHolder.Enemy.CalculateLerpValue() < GameConstants.EnemyBattleLimitValue)
            {
                AddEvent(false);
            }

            CalculateFightResults();
        }
        
        private void CalculateFightResults()
        {
            _currentLoopViewHandler.StartFightAction -= CalculateFightResults;
            _currentLoopViewHandler.AddEventAction -= AddEvent;
            float enemyValue = _currentbattleHolder.Enemy.CalculateLerpValue();
            float playerValue = _currentbattleHolder.Player.CalculateLerpValue();
            bool isPlayerWin = playerValue > enemyValue;
            UnitClass winner = isPlayerWin ? _currentbattleHolder.Player.CurrentUnit : _currentbattleHolder.Enemy.CurrentUnit;
            float damage = winner.Description.UnitCurrentDamage;
            FightCompleeteAction.Invoke(isPlayerWin,damage);
            ClearAllEvents();
        }
        
        private void ClearAllEvents()
        {
            ClearPlayerEvents();
            ClearEnemyEvents();
        }

        private void ClearPlayerEvents()
        {
            _currentLoopViewHandler.PlayerBattleEventDrawer.ClearEvents();
            _currentbattleHolder.Player.ClearEvents();
        }
        
        private void ClearEnemyEvents()
        {
            _currentLoopViewHandler.EnemyBattleEventDrawer.ClearEvents();
            _currentbattleHolder.Enemy.ClearEvents();
        }
    }
}
