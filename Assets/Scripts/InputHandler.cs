using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour{
    [SerializeField]private GameInput gameInput;
    private Apple targetedApple;


    void Start(){
        gameInput.OnActivateAction += GameInput_OnActivateAction;
        gameInput.OnClickAction += GameInput_OnClickAction;
        gameInput.OnTargetedAppleChanged += GameInput_OnTargetedAppleChanged;
    }

    private void GameInput_OnTargetedAppleChanged(object sender, GameInput.OnTargetedAppleChangedEventArgs e) {
        targetedApple = e.targetedApple;
    }

    private void GameInput_OnClickAction(object sender, EventArgs e) {
        if (targetedApple != null) { targetedApple.Activate(); }
    }

    private void GameInput_OnActivateAction(object sender, System.EventArgs e) {
        targetedApple.Activate();
    }
}
