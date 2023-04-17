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
        
    }
    
    //Passing the Waypoints Values to the AI Agent
    public Transform[] GetWaypoints()
    {
        return waypoints;
    }
}
