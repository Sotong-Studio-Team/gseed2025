using System.Collections.Generic;

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

        public static IDungeonConfig CretaeDungeonData(DungeonConfigSO dungeonConfigSO)
        {
            return new DungeonConfig(dungeonConfigSO.OtherPortalSpawnRate,
                                     dungeonConfigSO.EnemySpawnRate,
                                     dungeonConfigSO.CoinSpawnRate,
                                     dungeonConfigSO.EmptySpawnRate);
        }
    }
}
