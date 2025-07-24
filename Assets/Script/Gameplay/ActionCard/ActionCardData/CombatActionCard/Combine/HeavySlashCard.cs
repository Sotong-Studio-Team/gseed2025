using UnityEngine;

namespace SotongStudio.ActLink.Gameplay.ActionCard.Combat.Combined
{
    [CreateAssetMenu(menuName = "Test/Combine/Heavy Slash")]
    public class HeavySlashCard : BaseCombineCard
    {
        public override string ActionId => "CMB-ACT-CARD-HEAVY-SLASH";

        public override ActionCardType[] ActionTypes => new ActionCardType[] { ActionCardType.Strike };

        [field: SerializeField]
        public override int ActionPoint { get; protected set; }
    }
}
