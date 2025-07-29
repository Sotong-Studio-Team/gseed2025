namespace SotongStudio.Bomber.Gameplay.Bomb.Data
{
    public interface IBaseBombStat
    {
        int Damage { get; }
        ushort ExplosionLength { get; }
        float ExplosionDelay { get; }
        float ExplosionDuration { get; }
        float UseCooldown { get; }
    }

    public class BombStat: IBaseBombStat
    {
        public int Damage { get; set; }
        public ushort ExplosionLength { get; set; }
        public float ExplosionDelay { get; set; }
        public float ExplosionDuration { get; set; }
        public float UseCooldown { get; set; }

        public BombStat(int damage, ushort explosionLength, float explosionDelay, float explosionDuration, float useCooldown)
        {
            Damage = damage;
            ExplosionLength = explosionLength;
            ExplosionDelay = explosionDelay;
            ExplosionDuration = explosionDuration;
            UseCooldown = useCooldown;
        }
    }
}
