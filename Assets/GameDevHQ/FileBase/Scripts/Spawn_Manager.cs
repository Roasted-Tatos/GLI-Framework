using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    private static Spawn_Manager instance;
    public static Spawn_Manager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("The Spawn Manager is NULL");
            }
            return instance;
        }
    }

    [SerializeField] private List<GameObject> spawnedEnemy;
    [SerializeField] private GameObject EnemyAi;
    [SerializeField] private int spawnAmount;
    
    private Transform[] waypoints;
    private GameObject spawnUnit;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        waypoints = GameManager.Instance.GetWaypoints();

        spawnedEnemy = new List<GameObject>();

        for(int i = 0; i < spawnAmount; i++)
        {
            spawnUnit = Instantiate(EnemyAi, waypoints[0]);
            spawnUnit.SetActive(false);
            spawnedEnemy.Add(spawnUnit);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < spawnedEnemy.Count; i++)
        {
            if (!spawnedEnemy[i].activeInHierarchy)
            {
                return spawnedEnemy[i];
            }
        }
        return null;
    }

}
