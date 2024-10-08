namespace City
{
    public static class Resource
    {
        public static int ResourceValue;

        public static void AddResource(int addValue)
        {
            ResourceValue += addValue;
        }

        public static bool TryToRemoveResource(int remValue)
        {
            if (ResourceValue < remValue) return false;

            ResourceValue -= remValue;
            return true;
        }
    }
}