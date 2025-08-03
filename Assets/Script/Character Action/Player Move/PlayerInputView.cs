using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio.Bomber
{
    public class PlayerInputView : MonoBehaviour
    {
        public UnityEvent<Vector2> OnMovementInput;

        private void Update()
        {
            MovementInput();
        }

        private void MovementInput()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Vector2 movement = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                OnMovementInput?.Invoke(movement);
            }
            else
            {
                OnMovementInput?.Invoke(Vector2.zero);
            }
        }
    }
}
