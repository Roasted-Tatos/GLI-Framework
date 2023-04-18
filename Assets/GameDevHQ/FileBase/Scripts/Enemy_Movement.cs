using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    private enum AiState
    {
        Walking,
        Hiding,
        Death
    }

    [SerializeField] private int currentDestintation;
    [SerializeField] private AiState currentAiState;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private bool isHiding;

    public float HidingSeconds;
    private Transform[] waypoints;

    void Start()
    {
        waypoints = GameManager.Instance.GetWaypoints();

        currentAiState = AiState.Walking;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentAiState)
        {
            case AiState.Walking:
                if(currentAiState != AiState.Death)
                {
                    CalculateMovement();
                }
                break;
            case AiState.Hiding:
                if(currentAiState != AiState.Death)
                {
                    CalculateHiding();
                }
                break;
            case AiState.Death:
                CalculateDeath();
                break;
        }
    }

    void CalculateMovement()
    {
        _agent.isStopped = false;

        if(_agent.remainingDistance < 0.5f)
        {
            _agent.SetDestination(waypoints[currentDestintation].position);

            if (currentDestintation == waypoints.Length -1)
            {
                HidingTrigger();
                Debug.Log("Hiding");
            }
            else
            {
                currentDestintation++;
                Debug.Log("Moving");
            }
            
        }
    }
    void CalculateHiding()
    {
        HidingSeconds = Random.Range(1f, 5f);
        if(isHiding == true)
        {
            StartCoroutine(HidingTimer());
        }
    }

    IEnumerator HidingTimer()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(HidingSeconds);
        _agent.isStopped = false;
        isHiding = false;
        currentAiState = AiState.Walking;
    }

    void HidingTrigger()
    {
        isHiding = true;
        Debug.Log("Hiding Triggered");
        currentAiState = AiState.Hiding;
    }

    void CalculateDeath()
    {
        _agent.isStopped = true;
    }

    public void DeathTrigger()
    {
        currentAiState= AiState.Death;
        GameManager.Instance.AddPoints();
    }
}
