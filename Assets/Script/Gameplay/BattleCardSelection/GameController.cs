using SotongStudio.ActLink.Gameplay;

namespace SotongStudio.ActLink.Gameplay
{
    public interface IGameController
    {
        void CompareCardResult();
    }
    public class GameController : IGameController
    {
        private IBattleCardSelectionDataService _battleCardDataService;

        public void CompareCardResult()
        {
            var playerResult = _battleCardDataService.GetPlayerActionResult();     
            var enemyResult = _battleCardDataService.GetEnemyActionResult();
        }
    }
}
