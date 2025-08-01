using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Portal
{
    public interface IPortalObject : IInteractable
    {
        void RecivePlayerInteractionProcess();
    }
    public class PortalObject : DungeonObject, IPortalObject
    {
        public void Interact()
        {
            RecivePlayerInteractionProcess();
        }

        public virtual void RecivePlayerInteractionProcess()
        {
            
        }

        public override void TakeExplosionDamageProcess(int damage)
        {
            //Do Nothing
        }
    }
}
