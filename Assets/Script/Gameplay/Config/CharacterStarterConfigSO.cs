using SotongStudio.Bomber.Shared.Character;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Character
{
    [CreateAssetMenu(fileName = "Character Starter Config", menuName = "Config/CharacterStarterConfig")]
    public class CharacterStarterConfigSO : ScriptableObject, ICharacterStat
    {
        [SerializeField]
        private int _maxHealth;
        [SerializeField]
        private int _speed;
        [SerializeField]
        private int _maxBombAmount;

        public int MaxHealth => _maxHealth;
        public int Health => _maxHealth;
        public int Speed => _speed;
        public int BombAmount => _maxBombAmount;
        public int MaxBombAmount => _maxBombAmount;
        
    }
}
