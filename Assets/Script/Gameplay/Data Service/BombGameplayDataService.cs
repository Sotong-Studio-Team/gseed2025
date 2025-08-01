using SotongStudio.Bomber.Gameplay.Bomb.Data;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Bomb
{
    public interface IBombGameplayDataService
    {
        int GetBombDamage();
        ushort GetBombRange();
        float GetBombExplosionDelay();
        float GetBombExplosionDuration();
        float GetBombUseCooldown();
    }

    public interface IBombGameplayUpdateService
    {
        [System.Obsolete("Doesn't Need to Setup. Flow are Updated. This will Do Nothing")]
        void SetupBombStat(BombStat bombStat);

        void AddBombDamage(int amount);
        void ReduceBombDamage(int amount);

        void AddBombRange(ushort amount);
        void ReduceBombRange(ushort amount);
    }
    public class BombGameplayDataService : IBombGameplayUpdateService, IBombGameplayDataService
    {
        private BombStat _bombStat;

        public BombGameplayDataService(BombStarterConfigSO bombStartStat)
        {
            _bombStat = new(bombStartStat);
        }

        public void SetupBombStat(BombStat bombStat)
        {
            
        }

        public void AddBombDamage(int amount)
        {
            _bombStat.Damage += amount;
        }
        public void ReduceBombDamage(int amount)
        {
            _bombStat.Damage -= Mathf.Min(amount, ThresholdConfig.BombDamage);
        }

        public void AddBombRange(ushort amount)
        {
            _bombStat.ExplosionLength += amount;
        }
        public void ReduceBombRange(ushort amount)
        {
            _bombStat.ExplosionLength -= (ushort)Mathf.Min(amount, ThresholdConfig.ExplosionLength);
        }

        public int GetBombDamage()
        {
            return _bombStat.Damage;
        }
        public ushort GetBombRange()
        {
            return _bombStat.ExplosionLength;
        }
        public float GetBombExplosionDelay()
        {
            return _bombStat.ExplosionDelay;
        }
        public float GetBombExplosionDuration()
        {
            return _bombStat.ExplosionDuration;
        }
        public float GetBombUseCooldown()
        {
            return _bombStat.UseCooldown;
        }

    }
}
