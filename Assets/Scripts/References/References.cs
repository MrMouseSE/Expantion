using GlobalMap;
using UnityEngine;

namespace References
{
    public class References
    {
        public GlobalMapDescription GlobalMapDescription { get; private set; }
        
        public void BuildReferences()
        {
            GlobalMapDescription = Resources.Load("GlobalMapDescription") as GlobalMapDescription;
        }
    }
}