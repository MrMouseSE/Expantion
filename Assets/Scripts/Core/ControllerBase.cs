namespace Core
{
    public abstract class ControllerBase : IController
    {
        private bool _activated;
        protected GameController Manager;
        
        public void Activate(GameController manager)
        {
            if (_activated) return;
            Manager = manager;
            
            OnActivate();

            _activated = true;
        }

        public void Deactivate()
        {
            OnDeactivate();
            
            _activated = false;
        }
        
        protected abstract void OnActivate();
        protected abstract void OnDeactivate();
    }
}