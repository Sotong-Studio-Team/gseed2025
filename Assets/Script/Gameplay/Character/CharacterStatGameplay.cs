using SotongStudio.Bomber.Shared.Character;

namespace SotongStudio.Bomber.Gameplay.Character
{
    public class CharacterStatGameplay : ICharacterStat
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Speed { get; set; }
        public int BombAmount { get; set; }
        public int MaxBombAmount { get; set; }

        public CharacterStatGameplay(int health, int speed, int bombAmount)
        {
            Health = health;
            Speed = speed;
            BombAmount = bombAmount;
        }

        public CharacterStatGameplay(ICharacterStat characterStat)
        {
            Health = characterStat.Health;
            MaxHealth = characterStat.MaxHealth;
            Speed = characterStat.Speed;
            BombAmount = characterStat.BombAmount;
            MaxBombAmount = characterStat.MaxBombAmount;
        }
    }
}
