using System;
using Unit;

namespace Battle.BattleAction
{
    public class BattleLoopController
    {
        public Action<bool,float> FightCompleeteAction;
        private BattleLoopHandler _currentLoopHandler;
        private BattleHolder _currentbattleHolder;

        public void Init(BattleLoopHandler battleLoopHandler, BattleHolder battleHolder)
        {
            _currentLoopHandler = battleLoopHandler;
            _currentLoopHandler.StartFightAction += CalculateFightResults;
            _currentbattleHolder = battleHolder;
        }
        
        private void CalculateFightResults()
        {
            _currentLoopHandler.StartFightAction -= CalculateFightResults;
            float enemyValue = _currentbattleHolder.Enemy.CalculateLerpValue();
            float playerValue = _currentbattleHolder.Player.CalculateLerpValue();
            bool isPlayerWin = playerValue > enemyValue;
            UnitClass winner = isPlayerWin ? _currentbattleHolder.Player.CurrentUnit : _currentbattleHolder.Enemy.CurrentUnit;
            float damage = winner.Description.UnitCurrentDamage;
            FightCompleeteAction.Invoke(isPlayerWin,damage);
        }
    }
}
