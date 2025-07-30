using UnityEngine;

namespace SotongStudio.Bomber.Shared.Bomb
{
    public interface IBaseBombStat
    {
        int Damage { get; }
        ushort ExplosionLength { get; }
        float ExplosionDelay { get; }
        float ExplosionDuration { get; }
        float UseCooldown { get; }
    }
}
