using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.General
{
    public interface IEmptyObject : IDungeonObject
    {
        // This interface can be extended with specific methods or properties if needed.
    }
    public class EmptyObject : DungeonObject, IDungeonObject
    {
        public override void TakeExplosionDamageProcess(int damage)
        {
            //DO Nothing
        }
    }
}
