using UnityEngine;

namespace SotongStudio.ActLink.Gameplay.ActionCard.Combat
{
    [CreateAssetMenu(menuName = "Test/Basic/Defect")]
    public class DeflectCard : BaseActionCard, ICounterCard
    {
        public override string ActionId => "ACT-CRD-DEFLECT";

        public override ActionCardType[] ActionTypes => new ActionCardType[] { ActionCardType.Defense,
                                                                               ActionCardType.Counter };
        [field: SerializeField]
        public ushort PenaltyActionPoint { get; private set; }

        [field: SerializeField]
        public override int ActionPoint { get; protected set; }
    }
}
