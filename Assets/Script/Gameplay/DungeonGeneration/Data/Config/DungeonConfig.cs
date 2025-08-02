using System;
using System.Collections.Generic;
using UnityEditor;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    public interface IDungeonConfig
    {
        IEnumerable<IPortalSpawnRate> PortalSpawnRates { get; }

        IEnemySpawnRate EnemySpawnConfig { get; }
        IDungeonSpawnRate CoinSpawnConfig { get; }
        IDungeonSpawnRate EmptySpawnConfig { get; }

    }
    public class DungeonConfig : IDungeonConfig
    {
        public IEnumerable<IPortalSpawnRate> PortalSpawnRates { get; private set; }

        public IEnemySpawnRate EnemySpawnConfig { get; private set; }

        public IDungeonSpawnRate CoinSpawnConfig { get; private set; }

        public IDungeonSpawnRate EmptySpawnConfig { get; private set; }

        public DungeonConfig(IEnumerable<IPortalSpawnRate> portalSpawnRates,
                             IEnemySpawnRate enemySpawnConfig,
                             IDungeonSpawnRate coinSpawnConfig,
                             IDungeonSpawnRate emptySpawnConfig)
        {
            PortalSpawnRates = portalSpawnRates;
            EnemySpawnConfig = enemySpawnConfig;
            CoinSpawnConfig = coinSpawnConfig;
            EmptySpawnConfig = emptySpawnConfig;
        }

        private IDungeonConfig SetDungeonLevel(DungeonConfigSO dungeonConfigSO, int level)
        {
            if (level % dungeonConfigSO.IncreaseSapawnCoin == 0) { CoinSpawnConfig.AddWeight((ushort)(dungeonConfigSO.IncreaseSapawnCoin * level)); }
            if (level % dungeonConfigSO.IncreaseRateEmpty == 0) { CoinSpawnConfig.AddWeight((ushort)(dungeonConfigSO.IncreaseRateEmpty * level)); }
            if (level % dungeonConfigSO.IncreaseRateEnemy == 0) { CoinSpawnConfig.AddWeight((ushort)(dungeonConfigSO.IncreaseSapawnEnemy * level)); }


            return this;
        }

        public static IDungeonConfig CretaeDungeonData(DungeonConfigSO dungeonConfigSO, int level = 1)
        {
            var dungeonConfig = new DungeonConfig(dungeonConfigSO.OtherPortalSpawnRate,
                                     dungeonConfigSO.EnemySpawnRate,
                                     dungeonConfigSO.CoinSpawnRate,
                                     dungeonConfigSO.EmptySpawnRate);

            return dungeonConfig.SetDungeonLevel(dungeonConfigSO, level);
        }
    }
}
