using System;
using UnityEngine;

public class Apple : MonoBehaviour{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite redApple;
    [SerializeField] private Sprite grayApple;
    [SerializeField] private PuzzleComplete puzzleComplete;
    private bool activated;
    private Tile t1;
    private Tile t2;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Activate() {
        activated = !activated;
        int matchedChange = 0;
        if (activated) {
            spriteRenderer.sprite = redApple;
            matchedChange += t1.Increase();
            matchedChange += t2.Increase();
        }  else { 
            spriteRenderer.sprite = grayApple;
            matchedChange += t1.Decrease();
            matchedChange += t2.Decrease();
        }
        puzzleComplete.MatchedChanged(matchedChange);
    }

    public void SetTiles(Tile tile1, Tile tile2) {
        t1 = tile1;
        t2 = tile2;
    }

    public void SetCompleter(PuzzleComplete completer) { puzzleComplete = completer; }
}
