using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SotongStudio.InputPlayerController.Helper
{
    public static class InputSystemHelper
    {
        public static void SetupActionAsButtonClick(this PlayerInput playerInput, string actionName, UnityEvent clickEvent)
        {
            var action = playerInput.currentActionMap.FindAction(actionName);
            action.started += (callback) => { clickEvent.Invoke(); };
        }
        public static void SetupActionAsButtonClick<T>(this PlayerInput playerInput, string actionName, UnityEvent<T> clickEvent, T parameter)
        {
            var action = playerInput.currentActionMap.FindAction(actionName);
            action.started += (callback) => { clickEvent.Invoke(parameter); };
        }
        public static void SetupActionAsButtonHoldRelease(this PlayerInput playerInput, string actionName, UnityEvent<bool> holdReleaseEvent)
        {
            var action = playerInput.currentActionMap.FindAction(actionName);

            action.started += (callback) => { holdReleaseEvent.Invoke(true); };
            action.canceled += (callback) => { holdReleaseEvent.Invoke(false); };
        }
        public static void SetupActionAsDirectionInput(this PlayerInput playerInput, string actionName, UnityEvent<Vector2> getDirectionEvent)
        {
            var action = playerInput.currentActionMap.FindAction(actionName);
            action.performed += (callback) => { getDirectionEvent.Invoke(callback.ReadValue<Vector2>()); };
            action.canceled += (callback) => { getDirectionEvent.Invoke(Vector2.zero); };
        }
    }
}