using Battle.BattleAction;
using UnityEngine.Serialization;

namespace Battle.BattleSceneScripts
{
    public class BattleSceneUiController : AbstractUiController
    {
        public BattleHeroButtonsHandler Handler;

        [FormerlySerializedAs("LoopHandler")] public BattleLoopViewHandler loopViewHandler;
    }
}
