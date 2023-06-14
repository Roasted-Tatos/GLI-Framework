using GameDevHQ.FileBase.Plugins.FPS_Character_Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("That Game Manager is Null");
            }
            return instance;
        }
    }

    [SerializeField] private int totalPoints;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float currentTimer, maxTimer;
    [SerializeField] private GameObject winBanner, loseBanner, pauseBanner;
    [SerializeField] private bool isGamePaused;
    [SerializeField] private FPS_Controller cameraController;

    public float SpawnTimer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        totalPoints = 0;
        Time.timeScale = 1f;
        winBanner.SetActive(false);
        loseBanner.SetActive(false);
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Randomly Spawn AI Agents
        currentTimer += Time.deltaTime;
        if (currentTimer > SpawnTimer)
        {
            SpawningEnemy();
        }
        WinGame();

        PausedGame();
    }
    
    //Passing the Waypoints Values to the AI Agent
    public Transform[] GetWaypoints()
    {
        return waypoints;
    }

    void SpawningEnemy()
    {
        GameObject EnemyAI = Spawn_Manager.Instance.GetPooledObject();
        if (EnemyAI != null )
        {
            EnemyAI.gameObject.SetActive(true);
            SpawnTimer = Random.Range(2, maxTimer);
            currentTimer = 0;
        }

    }

    public void AddPoints()
    {
        totalPoints += 50;
    }

    public int totalScore()
    {
        return totalPoints;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f;
        loseBanner.SetActive(true);
        isGamePaused = true;
        cameraController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void WinGame()
    {
        if(totalPoints == 500)
        {
            Debug.Log("Win");
            Time.timeScale = 0f;
            winBanner.SetActive(true);
            isGamePaused = true;
            cameraController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public bool isGameMenuPaused()
    {
        return isGamePaused;
    }

    private void PausedGame()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("Game is Paused");
            isGamePaused = true;
            Time.timeScale = 0f;
            pauseBanner.SetActive(true);
            cameraController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Resumed Game");
        isGamePaused = false;
        Time.timeScale = 1f;
        pauseBanner.SetActive(false);
        cameraController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
