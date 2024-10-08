using UnityEngine;

namespace GlobalMap
{
    public sealed class TestGlobalMapManager : MonoBehaviour
    {
        [SerializeField] private GlobalMapUIController _uiController;
        
        public GameController GameController { get; private set; }
        public References.References References { get; private set; }

        private void Awake()
        {
            References = new References.References();
            References.BuildReferences();

            var mapModel = new GlobalMapModelView(References.GlobalMapDescription);
        }

        private void OnDestroy()
        {
        }
    }
}