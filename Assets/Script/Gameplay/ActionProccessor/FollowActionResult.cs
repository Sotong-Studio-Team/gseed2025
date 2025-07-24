namespace SotongStudio.ActLink.Gameplay.ActionProcessor
{
    public interface IFollowActionResult
    {
        bool CanFollowUp { get; }
        ushort FollowPoint { get; }
    }
    public class FollowActionResult : IFollowActionResult
    {
        public bool CanFollowUp { get; private set; }

        public ushort FollowPoint { get; private set; }

        public FollowActionResult(bool canFollowUp, ushort followPoint)
        {
            CanFollowUp = canFollowUp;
            FollowPoint = followPoint;
        }

        public static IFollowActionResult CreateFollowUpResult(bool canFollowUp, ushort followPoint) => new FollowActionResult(canFollowUp, followPoint);
    }
}
