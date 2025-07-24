#nullable enable

using SotongStudio.ActLink.Gameplay.ActionCard;
using SotongStudio.ActLink.Gameplay.ActionCard.Combat;

namespace SotongStudio.ActLink.Gameplay.ActionProcessor
{

    public interface IActionProcessor
    {
        IActionCardResult InputAction(IActionCard action);
        IActionCardResult InputActionAsChain(IActionCard action, IActionCardResult lastActionResult);

        void CompareCardAction(IActionCard firstAction, IActionCard secondAction);

        bool CanInputAsChain(IActionCard action, IActionCardResult? lastActionResult);
    }
    public class ActionProccessor : IActionProcessor
    {
        private static IActionCardResult InputAction(IActionCard action, bool asChainAction)
        {
            ActionProcessResult finalResult = new();

            foreach (var actionTag in action.ActionTypes)
            {
                if (actionTag == ActionCardType.Counter)
                {
                    InputCounterAction(action, finalResult);
                }
                else if (actionTag == ActionCardType.Follow)
                {
                    InputFollowAction(action, finalResult);
                }
            }
            finalResult.SetCard(action);
            finalResult.SetAsChain(asChainAction);

            return finalResult;
        }
        public IActionCardResult InputAction(IActionCard action)
        {
            return InputAction(action, false);
        }
        public IActionCardResult InputActionAsChain(IActionCard action, IActionCardResult lastActionResult)
        {
            var canInputChain = CanInputAsChain(action, lastActionResult);
            if (lastActionResult.CanCounter && canInputChain)
            {
                var newCard = ModifyCardForCounter(action, lastActionResult);
                return InputAction(newCard, true);
            }
            else if (lastActionResult.CanFollowUp && canInputChain)
            {
                return InputAction(action, true);

            }

            return new ActionProcessResult();
        }

        public bool CanInputAsChain(IActionCard action, IActionCardResult? lastActionResult)
        {
            if (lastActionResult == null) return false;

            if (lastActionResult.CanCounter)
            {
                return true;
            }
            else if (lastActionResult.CanFollowUp &&
                     action.ActionPoint <= lastActionResult.FollowPoint)
            {
                return true;
            }

            return false;
        }

        private static void InputCounterAction(IActionCard action, IActionCardResult currentResult)
        {
            if (action is ICounterCard counterCard)
            {
                var counterResult = CreateCounterResult(true, counterCard.PenaltyActionPoint);
                currentResult.Add(counterResult);

                return;
            }
            throw new System.InvalidOperationException("Action is not a Counter Card");
        }
        private static ICounterActionResult CreateCounterResult(bool canCounter, ushort penaltyPoint)
        {
            return CounterActionResult.CerateCounterResult(canCounter, penaltyPoint);
        }

        private static void InputFollowAction(IActionCard action, IActionCardResult currentResult)
        {
            if (action is IFollowUpCard followUpCard)
            {
                var FollowResult = CreateFollowUpResult(true, followUpCard.FollowActionPoint);
                currentResult.Add(FollowResult);

                return;
            }
            throw new System.InvalidOperationException("Action is not a Counter Card");
        }
        private static IFollowActionResult CreateFollowUpResult(bool canFollowUp, ushort followPoint)
        {
            return FollowActionResult.CreateFollowUpResult(canFollowUp, followPoint);
        }

        private static IActionCard ModifyCardForCounter(IActionCard actionCard,
                                                        IActionCardResult lastExecutedResult)
        {
            if (lastExecutedResult == null)
            {
                throw new System.InvalidOperationException("Cannot last Execute card Is Null. Try use InputAction instead");
            }

            if (actionCard is not IActionCardSetup modifCard)
            {
                throw new System.InvalidOperationException("Action card not Implement SetupCard");
            }

            modifCard.ReduceActionPoint(lastExecutedResult.PenaltyPoint);

            return actionCard;
        }

        public void CompareCardAction(IActionCard firstAction, IActionCard secondAction)
        {
            
        }
    }
}
