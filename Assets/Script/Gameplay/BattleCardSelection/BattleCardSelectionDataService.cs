#nullable enable

using SotongStudio.ActLink.Gameplay.ActionCard;
using SotongStudio.ActLink.Gameplay.ActionProcessor;


namespace SotongStudio.ActLink.Gameplay
{
    public interface IBattleCardSelectionDataServiceUpdate
    {
        void SetSelectedPlayerCard(IActionCard card);
        void SetSelectedEnemyCard(IActionCard card);

        void SetPlayerLastActionResult(IActionCardResult newActionResult);
        void SetEnemyLastActionResult(IActionCardResult newActionResult);
    }
    public interface IBattleCardSelectionDataService
    {
        IActionCardResult? GetPlayerActionResult();
        IActionCardResult? GetEnemyActionResult();
    }
    public class BattleCardSelectionDataService : IBattleCardSelectionDataService, IBattleCardSelectionDataServiceUpdate
    {
        public IActionCardResult? GetEnemyActionResult()
        {
            throw new System.NotImplementedException();
        }

        public IActionCardResult? GetPlayerActionResult()
        {
            throw new System.NotImplementedException();
        }

        public void SetEnemyLastActionResult(IActionCardResult newActionResult)
        {
            throw new System.NotImplementedException();
        }

        public void SetPlayerLastActionResult(IActionCardResult newActionResult)
        {
            throw new System.NotImplementedException();
        }

        public void SetSelectedEnemyCard(IActionCard card)
        {
            throw new System.NotImplementedException();
        }

        public void SetSelectedPlayerCard(IActionCard card)
        {
            throw new System.NotImplementedException();
        }
    }
}
