namespace SotongStudio.Bomber.Gameplay.DungeonObject.DropItem
{
    public interface IDropItem : IDungeonObject, IPickable
    {
        void OnPickUpProcess();
    }
    public class DropItem : DungeonObject, IDropItem
    {
        public virtual void OnPickUpProcess()
        {
            Destroy(gameObject);
        }

        public void PickUp()
        {
            OnPickUpProcess();
        }

        public override void TakeExplosionDamageProcess(int damage)
        {
            //Do Nothing
        }
    }
}
