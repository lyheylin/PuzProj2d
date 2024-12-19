using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    [SerializeField] private ClickableObjectSO appleSO;
    [SerializeField] private TileSO tileSO;
    [SerializeField] private PuzzleComplete puzzleComplete;
    private int puzzleWidth = 3;
    private int puzzleHeight = 3;
    private float tileSize = 10f;
    private float puzzleDensity = 0.3f;


    private Dictionary<int, Tile> tiles = new();
    private List<Apple> shortRows = new();
    private List<Apple> longRows = new();

    private void Awake() {
        puzzleDensity = Random.Range(0.3f, 0.5f);
        GeneratePuzzle(puzzleWidth, puzzleHeight);
        int zeroes = 0;
        for(int i=0;i<puzzleHeight*puzzleWidth;i++) {
            if (tiles[i].Value == 0) zeroes++;
        }
        puzzleComplete.SetMatched(zeroes);
        puzzleComplete.Goal = puzzleHeight * puzzleWidth;

        puzzleComplete.OnPuzzleCompletion += PuzzleComplete_OnPuzzleCompletion;
    }

    private void PuzzleComplete_OnPuzzleCompletion(object sender, System.EventArgs e) {
        //pause game show completion screen
    }

    private bool Flip(float chance) {
        return Random.value < chance;
    }
    private void GeneratePuzzle(int width, int height) {
        
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                Tile tile = Instantiate(tileSO.prefab).GetComponent<Tile>();
                tile.Value = 0;
                tile.transform.localPosition = new Vector3(j * tileSize + tileSize / 2, (height - i) * tileSize - tileSize / 2, 0);
                tiles.Add(i*width+j, tile);
            }
        }
        for (int i = 0; i < height; i++) {
            for(int j = 1; j < width; j++) {
                int tileIndex1 = i * width + j - 1;
                int tileIndex2 = i * width + j;
                Apple apple = Instantiate(appleSO.prefab).GetComponent<Apple>();
                apple.SetTiles(tiles[tileIndex1], tiles[tileIndex2]);
                apple.SetCompleter(puzzleComplete);
                apple.transform.localPosition = new Vector3(j * tileSize, (height - i) * tileSize - tileSize / 2, 0);
                shortRows.Add(apple);
                if (Flip(puzzleDensity)) {
                    tiles[tileIndex1].Value++;
                    tiles[tileIndex2].Value++;
                }
            }
        }
        for (int i = 1; i < height; i++) {
            for (int j = 0; j < width; j++) {
                int tileIndex1 = (i - 1) * width + j;
                int tileIndex2 = (i - 1) * width + j + width;
                Apple apple = Instantiate(appleSO.prefab).GetComponent<Apple>();
                apple.SetTiles(tiles[tileIndex1], tiles[tileIndex2]);
                apple.SetCompleter(puzzleComplete);
                apple.transform.localPosition = new Vector3(j * tileSize + tileSize/2, (height - i) * tileSize, 0);
                longRows.Add(apple);
                if (Flip(puzzleDensity)) {
                    tiles[tileIndex1].Value++;
                    tiles[tileIndex2].Value++;
                }
            }
        }
    }
}
