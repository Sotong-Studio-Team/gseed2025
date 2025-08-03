using UnityEngine.SceneManagement;

namespace SotongStudio.Bomber
{
    public interface IGameOverHUDLogic
    {
        void Show();
    }
    public class GameOverHUDLogic : IGameOverHUDLogic
    {
        private readonly IGameOverHUDView _view;


        public GameOverHUDLogic(IGameOverHUDView view)
        {
            _view = view;
            _view.OnPlayAgain.AddListener(PlayAgainProcess);
        }

        public void Show()
        {
            _view.Show();
        }

        private void PlayAgainProcess()
        {
            SceneManager.LoadScene("Main Gameplay");
        }
    }
}
