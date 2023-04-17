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

    private Transform[] waypoints;

    void Start()
    {
        waypoints = GameManager.Instance.GetWaypoints();

        currentAiState = AiState.Walking;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        _agent.isStopped = false;

        if(_agent.remainingDistance < 0.5f)
        {
            _agent.SetDestination(waypoints[currentDestintation].position);

            if (currentDestintation == waypoints.Length -1)
            {
                return;
            }
            else
            {
                currentDestintation++;
            }
        }
    }
}
