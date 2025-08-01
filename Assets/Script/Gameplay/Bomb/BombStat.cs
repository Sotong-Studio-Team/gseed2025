using SotongStudio.Bomber.Shared.Bomb;

namespace SotongStudio.Bomber.Gameplay.Bomb.Data
{
    public class BombStat : IBaseBombStat
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
        public BombStat(IBaseBombStat bombStat)
        {
            Damage = bombStat.Damage;
            ExplosionLength = bombStat.ExplosionLength;
            ExplosionDelay = bombStat.ExplosionDelay;
            ExplosionDuration = bombStat.ExplosionDuration;
            UseCooldown = bombStat.UseCooldown;
        }
    }
}
