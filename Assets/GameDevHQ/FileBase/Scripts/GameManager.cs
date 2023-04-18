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

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float currentTimer, maxTimer;

    public float SpawnTimer;

    private void Awake()
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
        currentTimer += Time.deltaTime;
        if (currentTimer > SpawnTimer)
        {
            SpawningEnemy();
        }
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
            Debug.Log("Spawning Timer reset");
        }

    }
}
