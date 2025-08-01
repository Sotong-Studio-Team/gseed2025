using SotongStudio.Bomber;
using Unity.VisualScripting;
using UnityEngine;
using VContainer.Unity;

public class PlayerMovementLogic : IStartable
{
    private readonly PlayerMovementView _view;
    private readonly PlayerMovementModel _model;
    private readonly PlayerInputView _inputView;

    public PlayerMovementLogic(PlayerMovementView view, PlayerMovementModel model, PlayerInputView inputView)
    {
        _view = view;
        _model = model;
        _inputView = inputView;

        _inputView.OnMovementInput.AddListener(CheckInput);
    }

    void IStartable.Start()
    {
        
    }

    private void CheckInput(Vector2 movement)
    {
        if (movement != Vector2.zero)
        {
            _view.MovePlayer(_model.MoveSpeed, movement);
            _model.UpdateLastDirection(movement);
        }

        if(_model.LastDirection.x < 0)
        {
            _view.FlipSprite(true);
        }
        else
        {
            _view.FlipSprite(false);
        }

        _view.AnimatePlayer(_model.LastDirection, movement);
    }
}
