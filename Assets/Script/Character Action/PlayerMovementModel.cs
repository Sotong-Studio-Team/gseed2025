using UnityEngine;

public class PlayerMovementModel
{
    public Vector2 Movement;
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
