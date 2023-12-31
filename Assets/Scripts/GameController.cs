using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ghostPrefab;
    public GameObject pinkGhostPrefab;
    public GameObject gameOverSign;
    public GameObject kabomGameObject;
    public int health = 4;
    public static GameController instance;
    private int totalScore;
    private int ghostsKilled = 0;
    private bool isGameOver = false;
    private bool hasKaboom = false;
    private int nextKaboom = 1000;
    public ScoreBoard scoreBoard;
    private Vector3[] spawnPoints = {
        new Vector3(-10f, 2.45f, 0f),
        new Vector3(-10f, 1.66f, 0f),
        new Vector3(-10f, 0f, 0f),
        new Vector3(-10f, -1.24f, 0f),
        new Vector3(-10f, -3.14f, 0f)
    };

    public GameObject[] healthGameObjects;


    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Restart game
        if (Input.GetKeyDown(KeyCode.F1)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Use kaboom if possible
        if (Input.GetKeyDown(KeyCode.Space) && hasKaboom) {
            UseKaboom();
        }

        // Stop game if gameOver
        if (isGameOver) {
            gameOverSign.SetActive(true);
            return;
        }

        float random = Random.Range(0f, 1f);
        if (random < 0.001f) {
            SpawnGhost();
        }

        kabomGameObject.SetActive(hasKaboom);
    }

    private void SpawnGhost()
    {
        Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        if (Random.Range(0f, 1f) < 0.1f) {
            Instantiate(pinkGhostPrefab, spawnPoint, Quaternion.identity);
        } else {
            Instantiate(ghostPrefab, spawnPoint, Quaternion.identity);
        }
    }

    public void GhostKilled(int points)
    {
        ghostsKilled++;
        totalScore += points;
        Debug.Log($"{ghostsKilled} ghosts killed.");
        Debug.Log($"{totalScore} points.");

        // Handle kaboom superpower
        if(totalScore >= nextKaboom) {
            hasKaboom = true;
            nextKaboom += 2000;
        }

        // Render scoreboard
        scoreBoard.ShowPoints(totalScore);
    }

    public void GhostSkippedBarrier()
    {
        healthGameObjects[health-1].SetActive(false);
        health--;

        if (health <= 0) {
            isGameOver = true;
            return;
        }

        Debug.Log($"{health} health points remaining.");
    }

    private void UseKaboom()
    {
        hasKaboom = false;

        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("ghost");
        foreach (GameObject ghost in ghosts) {
            ghost.GetComponent<Ghost>().Die();
        }
    }
}
