using SotongStudio.Bomber.Shared.Bomb;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Bomb
{
    [CreateAssetMenu(fileName = "Bomb Starter Config", menuName = "Config/BombStarterConfigSO")]
    public class BombStarterConfigSO : ScriptableObject, IBaseBombStat
    {
        [SerializeField]
        private int _damage;
        [SerializeField]
        private ushort _explosionLength;
        [SerializeField]
        private float _explosionDelay;
        [SerializeField]
        private float _explosionDuration;
        [SerializeField]
        private float _useCooldown;

        public int Damage => _damage;
        public ushort ExplosionLength => _explosionLength;
        public float ExplosionDelay => _explosionDelay;
        public float ExplosionDuration => _explosionDuration;
        public float UseCooldown => _useCooldown;
    }
}
