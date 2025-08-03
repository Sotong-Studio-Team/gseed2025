
using Cysharp.Threading.Tasks;
using DG.Tweening;
using SotongStudio.Bomber.Gameplay.LevelManager;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.Transition
{
    public interface ITransitionController
    {
        void MoveToMarket();
        void MoveToAltar();

        void MoveToNextLevel();
        void ReturnToMainMap();

        void SetReturnPos(Vector3? returnPos);
    }
    public class TransitionController : ITransitionController
    {
        private readonly TransitionComponent _transitionComponent;
        private readonly TransitionComponentMarket _marketTransitionComponent;
        private readonly TransitionComponentAltar _altarTransitionComponent;
        private readonly ILevelManager _levelManager;
        private readonly PlayerMovementLogic _playerMoveLogic;
        private Vector3? _returnPos;

        public TransitionController(TransitionComponent transitionComponent,
                                    TransitionComponentMarket marketTransitionComponent,
                                    TransitionComponentAltar altarTransitionComponent,
                                    PlayerMovementLogic playerMoveLogic,
                                    ILevelManager levelManager)
        {
            _transitionComponent = transitionComponent;
            _marketTransitionComponent = marketTransitionComponent;
            _altarTransitionComponent = altarTransitionComponent;
            _levelManager = levelManager;

            _playerMoveLogic = playerMoveLogic;
        }
        public void MoveToAltar()
        {
            MoveToAltarAsync().Forget();
        }
        private async UniTaskVoid MoveToAltarAsync()
        {

            await PlayStartTransitionAnimation();

            _transitionComponent.ConfinerCamera.BoundingShape2D = _altarTransitionComponent.CameraBound;
            _playerMoveLogic.TeleportPlayer(_altarTransitionComponent.SpawnPos.position);

            await UniTask.WaitForSeconds(0.5f);
            await PLayEndTransitionAnimation();
        }
        
        public void MoveToMarket()
        {
            MoveToMarketAsync().Forget();
        }
        private async UniTaskVoid MoveToMarketAsync()
        {

            await PlayStartTransitionAnimation();

            _transitionComponent.ConfinerCamera.BoundingShape2D = _marketTransitionComponent.CameraBound;
            _playerMoveLogic.TeleportPlayer(_marketTransitionComponent.SpawnPos.position);

            await UniTask.WaitForSeconds(1f);
            await PLayEndTransitionAnimation();
        }


        public void MoveToNextLevel()
        {
            MoveToNextLevelAsync().Forget();
        }
        public async UniTaskVoid MoveToNextLevelAsync()
        {
            await PlayStartTransitionAnimation();

            _levelManager.StartLevel();

            await UniTask.WaitForSeconds(0.5f);
            await PLayEndTransitionAnimation();
        }


        public void SetReturnPos(Vector3? returnPos)
        {
            _returnPos = returnPos;
        }

        public void ReturnToMainMap()
        {
            ReturnToMainMapAsync().Forget();
        }
        private async UniTaskVoid ReturnToMainMapAsync()
        {
            if (!_returnPos.HasValue) { return; }

            await PlayStartTransitionAnimation();

            _transitionComponent.ConfinerCamera.BoundingShape2D = _transitionComponent.MainMapCameraBound;
            _playerMoveLogic.TeleportPlayer(_returnPos.Value);

            await UniTask.WaitForSeconds(1f);
            await PLayEndTransitionAnimation();

            _returnPos = null;
        }


        private UniTask PlayStartTransitionAnimation()
        {
            _transitionComponent.TransitionImage.transform.localScale = Vector3.one;
            _transitionComponent.TransitionCanvasGroup.Show();

            return _transitionComponent.TransitionImage.DOScale(0, 0.5f).
                AsyncWaitForCompletion()
                .AsUniTask();
        }
        private async UniTask PLayEndTransitionAnimation()
        {
            _transitionComponent.TransitionImage.transform.localScale = Vector3.zero;
            await _transitionComponent.TransitionImage.DOScale(1, 0.5f)
                .AsyncWaitForCompletion()
                .AsUniTask();

            _transitionComponent.TransitionCanvasGroup.Hide();
        }
    }
}
