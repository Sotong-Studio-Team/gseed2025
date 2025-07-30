using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Portal
{
    public interface IPortalObject 
    {
        void RecivePlayerInteractionProcess();
    }
    public class PortalObject : DungeonObject, IPortalObject
    {
        public virtual void RecivePlayerInteractionProcess()
        {
            
        }

        public override void TakeExplosionDamageProcess(int damage)
        {
            //Do Nothing
        }
    }
}
