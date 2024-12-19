using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour {
    [SerializeField] private GameInput gameInput;
    [SerializeField] private AudioClip targetedAppleChangedAudio;
    [SerializeField] private Camera mainCamera;
    [SerializeField, Range(0f, 1f)] private float soundEffectVolume = 1f;

    private Apple targetedApple;
    public void Start() {
        gameInput.OnTargetedAppleChanged += GameInput_OnTargetedAppleChanged;
    }

    private void GameInput_OnTargetedAppleChanged(object sender, GameInput.OnTargetedAppleChangedEventArgs e) {
        if (targetedApple == null) {
            AudioSource.PlayClipAtPoint(targetedAppleChangedAudio, mainCamera.transform.localPosition, soundEffectVolume);
        }
        targetedApple = e.targetedApple;
    }
}