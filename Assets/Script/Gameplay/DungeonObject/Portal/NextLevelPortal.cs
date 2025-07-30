using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Portal
{
    public interface INextLevelPortal : IPortalObject
    {
        
    }   
    public class NextLevelPortal : PortalObject, INextLevelPortal
    {
        public override void RecivePlayerInteractionProcess()
        {
            //Do Next Level Process
        }
    }
}
