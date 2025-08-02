using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.DropItem
{
    public interface ICrystalDropItem : IDropItem
    {
        // Additional methods or properties specific to crystal drop items can be defined here.
    }   
    public class CrystalDropItem : DropItem, ICrystalDropItem
    {
        public override void OnPickUpProcess()
        {
            base.OnPickUpProcess();
        }
    }
}
