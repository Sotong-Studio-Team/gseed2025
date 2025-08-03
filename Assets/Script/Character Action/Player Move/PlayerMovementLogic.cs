using SotongStudio.Bomber;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using UnityEngine;
using VContainer.Unity;

public class PlayerMovementLogic : IStartable
{
    private readonly PlayerMovementView _view;
    private readonly PlayerInputView _inputView;

    private ICharacterGameplayDataService _characterDataService;

    public PlayerMovementLogic(PlayerMovementView view, PlayerInputView inputView, ICharacterGameplayDataService characterDataService)
    {
        _view = view;
        _inputView = inputView;

        _characterDataService = characterDataService;

        _inputView.OnMovementInput.AddListener(CheckInput);
    }

    private Vector2 _lastDirection = Vector2.down;

    void IStartable.Start()
    {
        
    }

    public void UpdateLastDirection(Vector2 movement)
    {
        _lastDirection = movement;
    }

    private void CheckInput(Vector2 movement)
    {
        if (movement != Vector2.zero && !_view._altarUI.activeSelf && !_view._marketUI.activeSelf)
        {
            _view.MovePlayer(_characterDataService.GetCharacterSpeed(), movement);
            UpdateLastDirection(movement);
        }

        if(_lastDirection.x < 0)
        {
            _view.FlipSprite(true);
        }
        else
        {
            _view.FlipSprite(false);
        }

        _view.AnimatePlayer(_lastDirection, movement);
    }

    public void TeleportPlayer(Vector2 newPos)
    {
       _view.transform.position = newPos;
    }
}
