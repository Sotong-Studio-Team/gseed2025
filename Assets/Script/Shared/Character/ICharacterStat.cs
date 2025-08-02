using UnityEngine;

namespace SotongStudio.Bomber.Shared.Character
{
    public interface ICharacterStat
    {
        int Health { get; }
        int MaxHealth { get; }
        float Speed { get; }
        int BombAmount { get; }
        int MaxBombAmount { get; }
    }
}
