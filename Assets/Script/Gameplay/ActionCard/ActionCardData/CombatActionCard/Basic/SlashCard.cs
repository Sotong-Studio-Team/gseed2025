using UnityEngine;

namespace SotongStudio.ActLink.Gameplay.ActionCard.Combat
{
    [CreateAssetMenu(menuName ="Test/Basic/Slash")]
    public class SlashCard : BaseActionCard
    {
        public override string ActionId => "ACT-CRD-SLASH";
        public override ActionCardType[] ActionTypes => new ActionCardType[] { ActionCardType.Strike };

        [field:SerializeField]
        public override int ActionPoint { get; protected set; }
    }
}
