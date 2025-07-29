namespace SotongStudio.Bomber.Gameplay.Character.DataService
{
    public interface ICharacterGameplayUpdateService
    {
        void SetupCharacterStat(CharacterStatGameplay characterStat);
        public void ReducePlayerHealth(int amount);
        public void AddPlayerHealth(int amount);

        public void ReducePlayerSpeed(int amount);
        public void AddPlayerSpeed(int amount);
    }
    public interface ICharacterGameplayDataService
    {
        public int GetPlayerCurrentHealth();
        public int GetPlayerSpeed();

    }
    public class CharacterGameplayDataService : ICharacterGameplayDataService, ICharacterGameplayUpdateService
    {
       
        private CharacterStatGameplay _characterStat;

        public int GetPlayerCurrentHealth()
        {
            return _characterStat.Health;
        }
        public int GetPlayerSpeed()
        {
            return _characterStat.Speed;
        }

        public void SetupCharacterStat(CharacterStatGameplay characterStat)
        {
            _characterStat = characterStat;
        }
        public void ReducePlayerHealth(int amount)
        {
            _characterStat.Health -= amount;
        }
        public void AddPlayerHealth(int amount)
        {
            _characterStat.Health += amount;
        }
        public void ReducePlayerSpeed(int amount)
        {
            _characterStat.Speed -= amount;
        }
        public void AddPlayerSpeed(int amount)
        {
            _characterStat.Speed += amount;
        }

    }
}
