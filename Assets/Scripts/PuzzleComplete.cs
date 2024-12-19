using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComplete : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite redApple;
    [SerializeField] private Sprite grayApple;
    private bool activated;
    public int Goal { set; private get; }
    private int matched = 0;

    public event EventHandler OnPuzzleCompletion;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Activate() {
        activated = !activated;
        if (activated) {
            spriteRenderer.sprite = redApple;
        } else {
            spriteRenderer.sprite = grayApple;
        }
    }

    public void SetMatched(int matched) { this.matched = matched; }

    public void MatchedChanged(int matchedChange) {
        matched += matchedChange;
        Debug.Log("Matched: " + matched);
        if (matched == Goal) activated = true;
        else activated = false;

        if (activated) OnPuzzleCompletion?.Invoke(this, EventArgs.Empty);

        if (activated) {
            spriteRenderer.sprite = redApple;
        } else {
            spriteRenderer.sprite = grayApple;
        }
    }
}
