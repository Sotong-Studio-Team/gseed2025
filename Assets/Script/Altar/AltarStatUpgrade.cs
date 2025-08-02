using UnityEngine;

namespace SotongStudio.Bomber
{
    public class AltarStatUpgrade 
    {
        public enum PlayerStatType
        {
            ExplosionLength,
            BombCount,
            MovementSpeed,
            MaxHealth
        }

        public PlayerStatType _statType;
        public string description;

        public AltarStatUpgrade(PlayerStatType _statsType, string descriptions)
        {
            this._statType = _statsType;
            this.description = descriptions;
        }
    }
}
