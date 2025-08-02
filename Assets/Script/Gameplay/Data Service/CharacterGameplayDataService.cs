using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Character.DataService
{
    public interface ICharacterGameplayUpdateService
    {
        [System.Obsolete("Doesn't Need to Setup. Flow are Updated. This will Do Nothing")]
        void SetupCharacterStat(CharacterStatGameplay characterStat);

        void AddPlayerHealth(int amount);
        void ReducePlayerHealth(int amount);

        void AddPlayerMaxHealth(int amount);
        void ReducePlayerMaxHealth(int amount);

        void AddPlayerSpeed(int amount);
        void ReducePlayerSpeed(int amount);

        void AddBombAmount(int amount);
        void ReduceBombAmount(int amount);

        void AddMaxBombAmount(int amount);
        void ReduceMaxBombAmount(int amount);
    }
    public interface ICharacterGameplayDataService
    {
        int GetCharacterMaxHealth();
        int GetCharacterCurrentHealth();
        int GetCharacterSpeed();
        int GetBombAmount();
        int GetMaxBombAmount();

    }
    public class CharacterGameplayDataService : ICharacterGameplayDataService, ICharacterGameplayUpdateService
    {

        private readonly CharacterStatGameplay _characterStat;

        public CharacterGameplayDataService(CharacterStarterConfigSO characterStat)
        {
            _characterStat = new(characterStat);
        }

        public int GetCharacterCurrentHealth()
        {
            return _characterStat.Health;
        }
        public int GetCharacterMaxHealth()
        {
            return _characterStat.MaxHealth;
        }
        public int GetCharacterSpeed()
        {
            return _characterStat.Speed;
        }
        public int GetBombAmount()
        {
            return _characterStat.BombAmount;
        }
        public int GetMaxBombAmount()
        {
            return _characterStat.MaxBombAmount;
        }

        public void SetupCharacterStat(CharacterStatGameplay characterStat)
        {
            
        }
        public void AddPlayerHealth(int amount)
        {
            _characterStat.Health += amount;
        }
        public void ReducePlayerHealth(int amount)
        {
            _characterStat.Health -= amount;
        }

        public void AddPlayerMaxHealth(int amount)
        {
            _characterStat.MaxHealth += amount;
        }
        public void ReducePlayerMaxHealth(int amount)
        {
            _characterStat.MaxHealth -= Mathf.Min(amount, ThresholdConfig.CharacterHealth);
        }

        public void AddPlayerSpeed(int amount)
        {
            _characterStat.Speed += amount;
        }
        public void ReducePlayerSpeed(int amount)
        {
            _characterStat.Speed -= Mathf.Min(amount, ThresholdConfig.CharacterSpeed);
        }

        public void AddBombAmount(int amount)
        {
            _characterStat.BombAmount += amount;
        }

        public void ReduceBombAmount(int amount)
        {
            _characterStat.BombAmount -= amount;
        }

        public void AddMaxBombAmount(int amount)
        {
            _characterStat.MaxBombAmount += amount;
        }

        public void ReduceMaxBombAmount(int amount)
        {
            _characterStat.BombAmount -= Mathf.Min(amount, ThresholdConfig.BombAmount);
        }

    }
}
