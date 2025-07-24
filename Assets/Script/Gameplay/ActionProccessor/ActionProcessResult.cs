#nullable enable

using SotongStudio.ActLink.Gameplay.ActionCard;

namespace SotongStudio.ActLink.Gameplay.ActionProcessor
{
    public interface IActionCardResult : ICounterActionResult, IFollowActionResult
    {
        IActionCard CardUsed { get; }
        bool IsChainAction { get; }
        void Add(ICounterActionResult counterResult);
        void Add(IFollowActionResult followResult);
    }


    public class ActionProcessResult : IActionCardResult
    {
        private ICounterActionResult? _counterResult = null;
        private IFollowActionResult? _followResult = null;

        public bool CanCounter => _counterResult?.CanCounter ?? false;

        public ushort PenaltyPoint => _counterResult?.PenaltyPoint ?? ushort.MinValue;

        public bool CanFollowUp => _followResult?.CanFollowUp ?? false;

        public ushort FollowPoint => _followResult?.FollowPoint ?? ushort.MinValue;

        private IActionCard? _cardUsed;
        public IActionCard CardUsed
        {
            get
            {
                if (_cardUsed == null)
                {
                    throw new System.InvalidOperationException("Cannot Get Card Used");
                }
                return _cardUsed;
            }
        }

        public bool IsChainAction { get; private set; }

        public void SetCard(IActionCard usedCard)
        {
            _cardUsed = usedCard;
        }

        public void SetAsChain(bool asChain)
        {
            IsChainAction = asChain;
        }
        public void Add(ICounterActionResult counterResult)
        {
            if (_counterResult != null)
            {
                throw new System.InvalidOperationException("Cannot Add CounterActionResult. Already Added");
            }

            _counterResult = counterResult;
        }
        public void Add(IFollowActionResult followResult)
        {
            if (_followResult != null)
            {
                throw new System.InvalidOperationException("Cannot Add FollowActionResult. Already Added");
            }

            _followResult = followResult;
        }

        public static IActionCardResult Combine(ICounterActionResult counterResult, IFollowActionResult followResult)
        {
            var result = new ActionProcessResult();
            result.Add(counterResult);
            result.Add(followResult);

            return result;

        }
    }
}
