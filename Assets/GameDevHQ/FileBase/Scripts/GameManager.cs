using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private GameObject winBanner, loseBanner;

    public float SpawnTimer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        totalPoints = 0;
        winBanner.SetActive(false);
        loseBanner.SetActive(false);
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
        Cursor.lockState = CursorLockMode.None;
    }

    public void WinGame()
    {
        if(totalPoints == 500)
        {
            Debug.Log("Win");
            Time.timeScale = 0f;
            winBanner.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
