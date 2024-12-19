using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite tile0;
    [SerializeField] private Sprite tile1;
    [SerializeField] private Sprite tile2;
    [SerializeField] private Sprite tile3;
    [SerializeField] private Sprite tile4;
    public int Value { set; get; } = 0;

    private int matched = 0;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if (Value == 0) spriteRenderer.sprite = tile0;
        if (Value == 1) spriteRenderer.sprite = tile1;
        if (Value == 2) spriteRenderer.sprite = tile2;
        if (Value == 3) spriteRenderer.sprite = tile3;
        if (Value == 4) spriteRenderer.sprite = tile4;
    }

    public int Increase() {
        bool preMatched = matched == Value;
        matched++;
        bool postMatched = matched == Value;
        int changed = 0;
        if (!preMatched && postMatched) changed++;
        if (preMatched && !postMatched) changed--;

        return changed;
    }
    public int Decrease() {
        bool preMatched = matched == Value;
        matched--;
        bool postMatched = matched == Value;
        int changed = 0;
        if (!preMatched && postMatched) changed++;
        if (preMatched && !postMatched) changed--;

        return changed;
    }
}
