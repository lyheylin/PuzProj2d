using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class GameInput : MonoBehaviour{

    public event EventHandler OnActivateAction;
    public event EventHandler OnDirectionRightAction;
    public event EventHandler OnDirectionLeftAction;
    public event EventHandler OnDirectionDownAction;
    public event EventHandler OnDirectionUpAction;
    public event EventHandler OnClickAction;

    public event EventHandler<OnTargetedAppleChangedEventArgs> OnTargetedAppleChanged;
    public class OnTargetedAppleChangedEventArgs : EventArgs {
        public Apple targetedApple;

    }
    private Apple targetedApple;

    private UserControls userControls;
    private Camera mainCamera;
    private void Awake() {
        mainCamera = Camera.main;
        
        userControls = new UserControls();
        userControls.Enable();

        //Events listeners
        userControls.Controls.Activate.performed += Activate_performed;
        userControls.Controls.DirectionUp.performed += DirectionUp_performed;
        userControls.Controls.DirectionLeft.performed += DirectionLeft_performed;
        userControls.Controls.DirectionDown.performed += DirectionDown_performed;
        userControls.Controls.DirectionRight.performed += DirectionRight_performed;
        userControls.Controls.Click.performed += Click_performed;
    }

    private void Update() {
        var ray = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (ray.collider) {
            ray.collider.TryGetComponent(out Apple target);
            if (!target.Equals(targetedApple)) {
                targetedApple = target;
                OnTargetedAppleChanged?.Invoke(this, new OnTargetedAppleChangedEventArgs() { targetedApple = target });
            }
        } else {
            if (targetedApple != null) {
                targetedApple = null;
                OnTargetedAppleChanged?.Invoke(this, new OnTargetedAppleChangedEventArgs() { targetedApple = null });
            }
        }
    }

    private void Click_performed(InputAction.CallbackContext obj) {
        OnClickAction?.Invoke(this, EventArgs.Empty);
    }

    private void DirectionRight_performed(InputAction.CallbackContext context) {
        OnDirectionRightAction?.Invoke(this, EventArgs.Empty);
    }

    private void DirectionDown_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnDirectionDownAction?.Invoke(this, EventArgs.Empty);
    }

    private void DirectionLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnDirectionLeftAction?.Invoke(this, EventArgs.Empty);
    }

    private void DirectionUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnDirectionUpAction?.Invoke(this, EventArgs.Empty);
    }

    private void Activate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnActivateAction?.Invoke(this, EventArgs.Empty);
    }
}
