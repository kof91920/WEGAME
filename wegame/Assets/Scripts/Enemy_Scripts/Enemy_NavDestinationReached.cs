using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_NavDestinationReached : MonoBehaviour {
    private Enemy_Master enemyMaster;
    private UnityEngine.AI.NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;


    private void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += DisableThis;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
    }

    private void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            CheckDestinationReached();
        }

    }
    void SetInitRef()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }
        checkRate = Random.Range(0.3f, 0.4f);
    }
    void CheckDestinationReached()
    {
        if (enemyMaster.isOnRoute)
        {
            if (myNavMeshAgent.remainingDistance < myNavMeshAgent.stoppingDistance)
            {
                enemyMaster.isOnRoute = false;
                enemyMaster.CallEventEnmeyReachedNavTarget();
            }
        }
    }
    void DisableThis()
    {
        this.enabled = false;
    }
}
