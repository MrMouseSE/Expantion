using Fight;
using Fight.FightEvents;
using ScenesManager;
using Unit;

namespace FightSceneScripts
{
    public class FightSceneController : ISceneController
    {
        public FightHeroButtonsHandler FightHeroButtonsHandler;
        public FightHolder FightHolder;

        private FightEventDescription _playerEvents;
        private FightEventDescription _enemyEvents;
        private UnitClass _enemyUnit;

        public void UpdateSceneData(AbstractUiController uiController)
        {
            FightHeroButtonsHandler = ((FightSceneUiController)uiController).Handler;
        }

        public void StartFight()
        {
            FightHolder = new FightHolder();
            var playerUnit = UnitFactory.GenerateUnit(FightHeroButtonsHandler.GetSelectedType());
            FightHolder.FillUnitsHolders(playerUnit, _playerEvents, _enemyUnit, _enemyEvents);
        }
    }
}
