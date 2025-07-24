using UnityEngine;

namespace SotongStudio.ActLink.Gameplay.ActionCard.Combat.Combined
{
    [CreateAssetMenu(menuName = "Test/Combine/Pich Needle")]
    public class PinchNeedleCard : BaseCombineCard, ICounterCard
    {
        public override string ActionId => "CMB-ACT-CARD-PINCH-NEEDLE";

        public override ActionCardType[] ActionTypes => new ActionCardType[] { ActionCardType.Defense,
                                                                               ActionCardType.Counter };

        [field:SerializeField]
        public ushort PenaltyActionPoint { get; private set; }

        [field: SerializeField]
        public override int ActionPoint { get; protected set; }
    }
}
