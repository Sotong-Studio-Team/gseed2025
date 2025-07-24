namespace SotongStudio.ActLink.Gameplay.ActionProcessor
{
    public interface ICounterActionResult
    {
        bool CanCounter { get; }
        ushort PenaltyPoint { get; }
    }

    public class CounterActionResult : ICounterActionResult
    {

        public bool CanCounter { get; private set; }

        public ushort PenaltyPoint { get; private set; }

        public CounterActionResult(bool canCounter, ushort penaltyPoint)
        {
            CanCounter = canCounter;
            PenaltyPoint = penaltyPoint;
        }

        public static ICounterActionResult CerateCounterResult(bool canCounter, ushort penaltyPoint) => new CounterActionResult(canCounter, penaltyPoint);

    }
}
