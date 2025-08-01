using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using SotongStudio.Bomber.Gameplay.DungeonGeneration.Service;
using SotongStudio.Bomber.Gameplay.LevelManager;
using UnityEngine;
using VContainer.Unity;

namespace SotongStudio.Bomber.Gameplay
{
    public class MainGameFlowControl : IInitializable
    {
        private readonly ILevelManager _levelManager;

        public MainGameFlowControl(ILevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        void IInitializable.Initialize()
        {
            //TestRegenerateDungeon().Forget();
        }

        private async UniTaskVoid TestRegenerateDungeon()
        {
            while (true)
            {
                await UniTask.WaitForSeconds(2);
                _levelManager.StartLevel();
                
                await UniTask.WaitForSeconds(3);
                var allSoftWalls = Object.FindObjectsByType<DungeonObject.DungeonObject>(FindObjectsSortMode.None);
                foreach (var wall in allSoftWalls)
                {
                    wall.TakeExplosionDamageProcess(1000);
                }

                await UniTask.WaitForSeconds(3);
            }
        }
    }
}
