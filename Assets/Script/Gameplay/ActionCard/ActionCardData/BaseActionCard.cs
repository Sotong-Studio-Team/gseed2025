using UnityEngine;

namespace SotongStudio.ActLink.Gameplay.ActionCard
{
    public interface IActionCard
    {
        string ActionId { get; }
        ActionCardType[] ActionTypes { get; }
        int ActionPoint { get; }
    }

    public interface IActionCardSetup
    {
        void ReduceActionPoint(ushort actionPoint);
    }
    public abstract class BaseActionCard : ScriptableObject, IActionCard, IActionCardSetup
    {
        public abstract string ActionId { get; }
        public abstract ActionCardType[] ActionTypes { get; }
        
        public abstract int ActionPoint { get; protected set; }

        public string ItemId => ActionId;

        public void ReduceActionPoint(ushort actionPoint)
        {
            ActionPoint -= actionPoint;
        }
    }
}