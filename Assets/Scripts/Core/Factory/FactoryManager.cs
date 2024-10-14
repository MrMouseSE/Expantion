namespace Core.Factory
{
    public static partial class FactoryManager
    {
        public static Factory Factory { get; private set; }

        public static void Init()
        {
            Factory = new Factory();
        }
    }
}