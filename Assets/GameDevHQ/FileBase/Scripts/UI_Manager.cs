using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private static UI_Manager instance;
    public static UI_Manager Instance
    { get { return instance; } }

    private void Awake()
    {
        instance = this; 
    }

    [SerializeField] private Text score;
    [SerializeField] private Text ammo;
    [SerializeField] private Shooting shootingScript;
    [SerializeField] private Text enemiesLeft;
    [SerializeField] private float timeValue = 120f;
    [SerializeField] private Text timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = GameManager.Instance.totalScore().ToString();
        ammo.text = shootingScript.TotalAmmo().ToString();
        enemiesLeft.text = Spawn_Manager.Instance.TotalEnemiesLeft().ToString();
        Timer();
    }

    void Timer()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            Debug.Log("Time Out");
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay= 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
