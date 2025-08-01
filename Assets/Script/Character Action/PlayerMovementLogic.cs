using UnityEngine;
using VContainer.Unity;

public class PlayerMovementLogic : IStartable
{
    private readonly PlayerMovementView _view;
    private readonly PlayerMovementModel _model;

    public PlayerMovementLogic(PlayerMovementView view, PlayerMovementModel model)
    {
        _view = view;
        _model = model;

        _view.OnUpdate += HandleInput;
    }

    void IStartable.Start()
    {
        
    }

    private void HandleInput()
    {
        _view.AnimatePlayer(_model.LastDirection, _model.Movement);

        CheckInput();
    }

    private void CheckInput()
    {
        _model.Movement.x = Input.GetAxis("Horizontal");
        _model.Movement.y = Input.GetAxis("Vertical");

        if (_model.Movement != Vector2.zero)
        {
            _view.MovePlayer(_model.MoveSpeed, _model.Movement);
            _model.UpdateLastDirection(_model.Movement);
        }

        if(_model.LastDirection.x < 0)
        {
            _view.FlipSprite(true);
        }
        else
        {
            _view.FlipSprite(false);
        }
    }

    public void TeleportPlayer(Vector3 newPos)
    {
       _view.transform.position = newPos;
    }
}
