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

        public BattleEvent GenerateNewFightEvent()
        {
            CurrentBattleEvent = BattleEventFactory.GenerateFightEvent(Description);
            return CurrentBattleEvent;
        }
    }
}
