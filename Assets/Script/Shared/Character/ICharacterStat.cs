using UnityEngine;

namespace SotongStudio.Bomber.Shared.Character
{
    public interface ICharacterStat
    {
        int Health { get; }
        int Speed { get; }
        int BombAmount { get; }
    }
}
