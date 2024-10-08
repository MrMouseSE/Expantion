namespace Fight.FightEvents
{
    public class FightEventsController
    {
        public FightEventDescription Description;
        public FightEvent CurrentFightEvent;

        public FightEventsController(FightEventDescription description)
        {
            Description = description;
        }

        public void GenerateNewFightEvent()
        {
            CurrentFightEvent = FightEventFactory.GenerateFightEvent(Description);
        }

        public FightEvent GetFightEvent()
        {
            return CurrentFightEvent;
        }

        public void ClearFightEvent()
        {
            CurrentFightEvent = null;
        }
    }
}
