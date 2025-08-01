using UnityEngine;

public class PlayerMovementModel
{
    public Vector2 Movement = Vector2.zero;
    public Vector2 LastDirection = Vector2.down;
    public float MoveSpeed = 10f;

    public void UpdateLastDirection(Vector2 movement)
    {
        LastDirection = movement;
    }

    public void UpdateMoveSpeed(float amount)
    {
        MoveSpeed += amount;
    }
}
