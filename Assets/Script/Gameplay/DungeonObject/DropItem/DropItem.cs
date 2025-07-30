namespace SotongStudio.Bomber.Gameplay.DungeonObject.DropItem
{
    public interface IDropItem : IDungeonObject
    {
        void OnPickUpProcess();
    }
    public class DropItem : DungeonObject, IDropItem
    {
        public virtual void OnPickUpProcess()
        {
            
        }

        public override void TakeExplosionDamageProcess(int damage)
        {
            //Do Nothing
        }
    }
}
