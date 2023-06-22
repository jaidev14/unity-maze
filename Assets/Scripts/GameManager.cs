using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Maze mazePrefab;
    private Maze mazeInstance;
    private void Start()
    {
        BeginGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            RestartGame();
        }
    }

    private void BeginGame() {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        // mazeInstance.Generate();
        StartCoroutine(mazeInstance.Generate());
    }
    private void RestartGame() {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
