using UnityEngine;

namespace SotongStudio.ActLink.Gameplay.ActionCard
{
    [CreateAssetMenu(menuName = "Test/Basic/Block")]
    public class BlockCard : BaseActionCard
    {
        public override string ActionId => "ACT-CRD-BLOCK";

        public override ActionCardType[] ActionTypes => new ActionCardType[] { ActionCardType.Defense };

        [field: SerializeField]
        public override int ActionPoint { get; protected set; }
    }
}
