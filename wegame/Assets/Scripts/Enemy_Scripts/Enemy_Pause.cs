using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Pause : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private NavMeshAgent myAgent;
    private float pasueValue = 1;

    private void OnEnable()
    {
        setInit();
        enemyMaster.EventEnemyDie += DisableThis;
        enemyMaster.EventEnemyDeductHealth += PauseAgent;
    }

    private void onDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
        enemyMaster.EventEnemyDeductHealth -= PauseAgent;
    }

    void setInit()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            myAgent = GetComponent<NavMeshAgent>();
        }
    }

    void PauseAgent(int dummy)
    {
        if(myAgent != null)
        {
            if (myAgent.enabled)
            {
                myAgent.ResetPath();
                enemyMaster.isNavPaused = true;
                StartCoroutine(restartAgent());
            }
        }
    }

    IEnumerator restartAgent()
    {
        yield return new WaitForSeconds(pasueValue);
        enemyMaster.isNavPaused = false; 
    }

    void DisableThis()
    {
        StopAllCoroutines();
    }
}
