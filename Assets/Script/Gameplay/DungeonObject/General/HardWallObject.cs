#nullable enable

namespace SotongStudio.Bomber.Gameplay.DungeonObject
{
    public interface IHardWallObject : IDungeonObject
    {
    }
    public class HardWallObject : DungeonObject, IHardWallObject
    {

        public override void TakeExplosionDamageProcess(int damage)
        {
           // Do Nothing
        }
    }
}
