#nullable enable

using SotongStudio.ActLink.Gameplay.ActionCard;
using SotongStudio.ActLink.Gameplay.ActionProcessor;
using UnityEngine;

namespace SotongStudio.ActLink.Gameplay.PlayerActionController
{
    public interface IPlayerCardSelectionController
    {
        void SelectCardAction(IActionCard actionCard);
    }

    public class PlayerCardSelectionController : IPlayerCardSelectionController
    {
        private readonly IBattleCardSelectionDataServiceUpdate _battleCardSelectionDataServiceUpdate;
        private readonly IBattleCardSelectionDataService _battleCardDataService;

        private readonly IActionProcessor _actionProcessor;

        public PlayerCardSelectionController(IActionProcessor actionProcessor,
                                            IBattleCardSelectionDataServiceUpdate battleCardSelectionDataServiceUpdate,
                                            IBattleCardSelectionDataService battleCardDataService)
        {
            _actionProcessor = actionProcessor;
            _battleCardSelectionDataServiceUpdate = battleCardSelectionDataServiceUpdate;
            _battleCardDataService = battleCardDataService;
        }

        public void SelectCardAction(IActionCard actionCard)
        {
            var lastExecutedResult = _battleCardDataService.GetPlayerActionResult();
            IActionCardResult newActionResult;

            var isChainPossible = _actionProcessor.CanInputAsChain(actionCard, lastExecutedResult);
            if (isChainPossible)
            {
                newActionResult = _actionProcessor.InputActionAsChain(actionCard, lastExecutedResult!); // null already check in CanInputAsChain
            }
            else
            {
                newActionResult = _actionProcessor.InputAction(actionCard);
            }

            _battleCardSelectionDataServiceUpdate.SetPlayerLastActionResult(newActionResult);

            Debug.Log($"Execute Card : Base : {actionCard.ActionId}{actionCard.ActionPoint} | New Card : {newActionResult.CardUsed.ActionPoint} | As Chain : {newActionResult.IsChainAction} || Result :  Follow - {newActionResult.CanFollowUp} | Counter - {newActionResult.CanCounter}");
            Debug.Log($"Result :  Follow - {newActionResult.CanFollowUp} | Counter - {newActionResult.CanCounter}");
        }
    }
}
