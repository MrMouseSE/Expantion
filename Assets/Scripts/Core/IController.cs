namespace Core
{
    public interface IController
    {
        void Activate(GameController controller);
        void Deactivate();
    }
}