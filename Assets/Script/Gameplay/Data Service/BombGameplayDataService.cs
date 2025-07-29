using SotongStudio.Bomber.Gameplay.Bomb.Data;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Bomb
{
    public interface IBombGameplayUpdateService
    {
        void SetupBombStat(BombStat bombStat);

        void ReduceBombDamage(int amount);
        void AddBombDamage(int amount);
        void ReduceBombRange(ushort amount);
        void AddBombRange(ushort amount);
    }
    public class BombGameplayDataService : IBombGameplayUpdateService
    {
        private BombStat _bombStat;
        public void SetupBombStat(BombStat bombStat)
        {
            _bombStat = bombStat;
        }
        public void ReduceBombDamage(int amount)
        {
            _bombStat.Damage -= amount;
        }
        public void AddBombDamage(int amount)
        {
            _bombStat.Damage += amount;
        }
        public void ReduceBombRange(ushort amount)
        {
            _bombStat.ExplosionLength -= amount;
        }
        public void AddBombRange(ushort amount)
        {
            _bombStat.ExplosionLength += amount;
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
