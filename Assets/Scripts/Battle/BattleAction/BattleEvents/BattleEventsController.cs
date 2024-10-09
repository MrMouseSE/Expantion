namespace Battle.BattleAction.BattleEvents
{
    public class BattleEventsController
    {
        public BattleEventDescription Description;
        public BattleEvent CurrentBattleEvent;

        public BattleEventsController(BattleEventDescription description)
        {
            Description = description;
        }

        public void GenerateNewFightEvent()
        {
            CurrentBattleEvent = BattleEventFactory.GenerateFightEvent(Description);
        }

        public BattleEvent GetFightEvent()
        {
            return CurrentBattleEvent;
        }

        public void ClearFightEvent()
        {
            CurrentBattleEvent = null;
        }
    }
}
