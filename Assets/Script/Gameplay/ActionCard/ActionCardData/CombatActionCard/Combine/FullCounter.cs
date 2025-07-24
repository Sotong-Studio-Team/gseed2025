using UnityEngine;

namespace SotongStudio.ActLink.Gameplay.ActionCard.Combat.Combined
{
    [CreateAssetMenu(menuName = "Test/Combine/Full Counter")]
    public class FullCounter : BaseCombineCard, IFollowUpCard
    {
        public override string ActionId => "CMB-ACT-CARD-FULL-COUNTER";

        public override ActionCardType[] ActionTypes => new ActionCardType[] { ActionCardType.Defense,
                                                                               ActionCardType.Follow};
        [field:SerializeField]
        public ushort FollowActionPoint { get; private set; }

        [field: SerializeField]
        public override int ActionPoint { get; protected set; }
    }
}
