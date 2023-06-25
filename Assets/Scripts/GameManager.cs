using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Maze mazePrefab;
    private Maze mazeInstance;
    public Player playerPrefab;
    private Player playerInstance;
    private void Start()
    {
        StartCoroutine(BeginGame());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            RestartGame();
        }
    }

    private IEnumerator BeginGame() {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        // mazeInstance.Generate();
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        yield return StartCoroutine(mazeInstance.Generate());
        playerInstance = Instantiate(playerPrefab) as Player;
        playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
        Camera.main.clearFlags = CameraClearFlags.Depth;

    }
    private void RestartGame() {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        if (playerInstance != null) {
            Destroy(playerInstance);
        }
        StartCoroutine(BeginGame());
    }
}
