using System.Collections.Generic;
using System.Linq;
using SotongStudio.Bomber.Gameplay.DungeonGeneration.Data;
using SotongStudio.Bomber.Shared.Dungeon.Cluster;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Service
{
    public interface IDungeonGenerationService
    {
        void GenerateDungeon(IDungeonConfig dungeonConfig);
        Vector3 GetPlayerStartPos();
    }
    public class DungeonGenerationService : IDungeonGenerationService
    {
        private readonly IClusterCollection _clusterCollection;
        private readonly IDungeonObjectConfigCollection _dungeonObjectCollection;
        private readonly IDngeonGenerationLogic _generationLogic;

        private int _generatedAmount = 0;

        private Dictionary<int, int> _mapSizeConfig = new Dictionary<int, int>()
        {
            {10,2},
            {20,4},
            {25,5}
        };

        public DungeonGenerationService(IClusterCollection clusterCollection,
                                        IDungeonObjectConfigCollection dungeonObjectConfigCollection,

                                        IDngeonGenerationLogic generationLogic)
        {
            _clusterCollection = clusterCollection;
            _dungeonObjectCollection = dungeonObjectConfigCollection;
            _generationLogic = generationLogic;
        }

        public void GenerateDungeon(IDungeonConfig dungeonConfig)
        {
            CleanUpDungeon();
            var dungeonData = GenerateDungeonData(dungeonConfig);
            _generationLogic.GenerateDugeonObject(dungeonData);
            _generationLogic.UpdateNavigationSurface();

            _generatedAmount++;
        }


        public Vector3 GetPlayerStartPos() => _generationLogic.GetPlayerStartPos();
        private IDugeonGeneratedData GenerateDungeonData(IDungeonConfig dungeonConfig)
        {
            var allClusters = GetClusters();
            var dungeonObject = GetDungeonObjects(allClusters, dungeonConfig);

            return new DungeonGeneratedData(dungeonObject, allClusters);
        }

        #region Cluster
        private IEnumerable<IGeneratedClusterData> GetClusters()
        {
            List<IGeneratedClusterData> generatedClusters = new();

            var allAvailableClusters = _clusterCollection.GetAllItems();

            var selectedConfig = Mathf.Clamp(_generatedAmount / 2, 0, 2);

            var blockAmount = _mapSizeConfig.ElementAt(selectedConfig).Key;
            var rowAmount = _mapSizeConfig.ElementAt(selectedConfig).Value;


            int layoutX = 0;
            int layoutY = 0;

            for (int i = 0; i < blockAmount; i++)
            {
                if (i > 0)
                {
                    if (i % rowAmount == 0 && i != 0)
                    {
                        layoutX++;
                        layoutY = 0;
                    }
                    else
                    {
                        layoutY++;
                    }
                }
                var selectClusterIndex = Random.Range(0, allAvailableClusters.Count());
                var clusterConfig = allAvailableClusters.ElementAt(selectClusterIndex);

                var cluster = CreateCluster(clusterConfig, new Vector2Int(layoutX, layoutY));
                generatedClusters.Add(cluster);
            }

            return generatedClusters;
        }

        private IGeneratedClusterData CreateCluster(IClusterConfig clusterConfig, Vector2Int layoutCoordinate)
        {
            Vector2Int padding = new Vector2Int(3 * layoutCoordinate.x, 3 * layoutCoordinate.y);
            var rotationNumber = Random.Range(0, 4);
            var direction = (ClusterRoationType)rotationNumber;

            List<Vector2Int> blockedTileResult = new();
            foreach (var blockedTile in clusterConfig.BlockedTiles)
            {
                var newCoordinate = Rotate(blockedTile, direction);
                blockedTileResult.Add(newCoordinate + padding);
            }
            List<Vector2Int> emptyTileResult = new();
            foreach (var emptyTile in clusterConfig.EmptyTiles)
            {
                var newCoordinate = Rotate(emptyTile, direction);
                emptyTileResult.Add(newCoordinate + padding);
            }

            return new GeneratedClusterData(clusterConfig.ItemId, direction, layoutCoordinate, blockedTileResult, emptyTileResult);


        }

        private Vector2Int Rotate(Vector2Int originalCoordinate, ClusterRoationType rotation)
        {
            switch (rotation)
            {
                case ClusterRoationType.Up:
                    return originalCoordinate;
                case ClusterRoationType.Right:
                    return new Vector2Int(originalCoordinate.y, -originalCoordinate.x);
                case ClusterRoationType.Down:
                    return new Vector2Int(-originalCoordinate.x, -originalCoordinate.y);
                case ClusterRoationType.Left:
                    return new Vector2Int(-originalCoordinate.y, originalCoordinate.x);
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(rotation), rotation, null);
            }
        }

        #endregion

        #region Spawn Object
        private IEnumerable<IGeneratedObjectData> GetDungeonObjects(IEnumerable<IGeneratedClusterData> generatedCluster,
                                                                   IDungeonConfig dungeonConfig)
        {
            List<IGeneratedObjectData> result = new();

            var availablePlacement = GetAvailablePlacement(generatedCluster);

            var portals = GeneratePortals(ref availablePlacement, dungeonConfig.PortalSpawnRates);
            result.AddRange(portals);

            foreach (var remainingPos in availablePlacement)
            {
                var other = GenerateOther(remainingPos,
                                          dungeonConfig.EnemySpawnConfig,
                                          dungeonConfig.CoinSpawnConfig,
                                          dungeonConfig.EmptySpawnConfig);
                result.Add(other);
            }
            return result;
        }

        private IEnumerable<IGeneratedObjectData> GeneratePortals(ref List<Vector2Int> availablePlacement, IEnumerable<IPortalSpawnRate> otherPortals)
        {
            List<IGeneratedObjectData> generatedPortals = new();

            //Adding Level Portal
            //TODO : Need better Way to Get Portal level. Maybe Create Data Factory
            var levelPortalPos = GetObjectPlaceCoordinate(ref availablePlacement);
            var levelPortal = new GeneratedObjectData("DUN-OBJ-POR-LEVEL", true, levelPortalPos);
            generatedPortals.Add(levelPortal);

            var numberGet = Random.Range(0, 2);
            if (numberGet > 0) { return generatedPortals; }

            foreach (var protal in otherPortals)
            {
                if (numberGet <= protal.SpawnRate)
                {
                    var isCovered = GetCoveredStatus(protal.DungeonObjectId);

                    var position = GetObjectPlaceCoordinate(ref availablePlacement);

                    var portalObject = new GeneratedObjectData(protal.DungeonObjectId, isCovered, position);

                    generatedPortals.Add(portalObject);
                }
            }

            return generatedPortals;
        }
        private IGeneratedObjectData GenerateOther(Vector2Int selectedCoordinate, params IDungeonSpawnRate[] othersObject)
        {
            IDungeonSpawnRate selectedObj = null;

            var allValue = othersObject.Select(data => data.SpawnRate).Sum(op => op);

            int randomNumber = Random.Range(1, allValue);
            int cumulativeChance = 0;

            foreach (var obj in othersObject)
            {
                cumulativeChance += obj.SpawnRate;
                if (randomNumber <= cumulativeChance)
                {
                    selectedObj = obj;
                    break;
                }
            }

            switch (selectedObj)
            {
                case IEnemySpawnRate enemySpawnRate:
                    return GenerateEnemy(enemySpawnRate, selectedCoordinate);

                default:
                    var dunObjId = selectedObj.DungeonObjectId;
                    return new GeneratedObjectData(dunObjId, GetCoveredStatus(dunObjId), selectedCoordinate);


            }
        }

        private IGeneratedObjectData GenerateEnemy(IEnemySpawnRate enemySpawnRate, Vector2Int selectedCoordinate)
        {
            int randomNumber = Random.Range(1, 101);

            int cumulativeChance = 0;
            foreach (var enemy in enemySpawnRate.EnemyUnits)
            {
                cumulativeChance += enemy.SpawnRate;
                if (randomNumber <= cumulativeChance)
                {
                    return new GeneratedObjectData(enemy.EnemyUnitId,
                                                   GetCoveredStatus(enemy.EnemyUnitId),
                                                   selectedCoordinate);
                }
            }
            throw new System.InvalidOperationException($"Something wrong in Random Number. number : {randomNumber} | comulative :{cumulativeChance}");
        }

        private Vector2Int GetObjectPlaceCoordinate(ref List<Vector2Int> availablePlacement)
        {
            var positionIndex = Random.Range(0, availablePlacement.Count);
            var position = availablePlacement[positionIndex];
            availablePlacement.RemoveAt(positionIndex);

            return position;
        }
        private List<Vector2Int> GetAvailablePlacement(IEnumerable<IGeneratedClusterData> availableClusters)
        {
            List<Vector2Int> availablePlacement = new();
            foreach (var cluster in availableClusters)
            {
                availablePlacement.AddRange(cluster.EmptyTile);
            }

            return availablePlacement;
        }
        private bool GetCoveredStatus(string objectId)
        {
            var selectedConfig = _dungeonObjectCollection.GetItem(objectId);
            var selectNumber = Random.Range(0, 100);

            return selectNumber <= selectedConfig.ObjectCoverChance;
        }
        #endregion

        private void CleanUpDungeon()
        {
            _generationLogic.CleanUpDungeon();
        }
    }
}
