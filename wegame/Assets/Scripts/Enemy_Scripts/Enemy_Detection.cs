using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detection : MonoBehaviour {
    private Enemy_Master enemyMaster;
    private Transform myTransform;
    public Transform head;
    public LayerMask playerLayer;
    public LayerMask sightLayer;
    private float checkRate;
    private float nextCheck;
    private float detectRadius = 80;
    private RaycastHit hit;

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
        CarryOutDetection();
    }
    void SetInitRef()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        myTransform = transform;

        if (head == null)
        {
            head = myTransform;
        }
        checkRate = Random.Range(0.8f, 1.2f);
    }

    bool CanPotentialTargetBeSeen(Transform potentialTarget)
    {
        if(Physics.Linecast(head.position, potentialTarget.position, out hit, sightLayer))
        {
            if(hit.transform == potentialTarget)
            {
                enemyMaster.CallEventEnemySetNavTarget(potentialTarget);
                return true;    
            }
            else
            {
                enemyMaster.CallEventEnmeyLostTarget();
                return false;
            } 
        }
        else
        {
            enemyMaster.CallEventEnmeyLostTarget();
            return false;
        }
    }

    void CarryOutDetection()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            Collider[] colliders = Physics.OverlapSphere(myTransform.position, detectRadius, playerLayer);

            if (colliders.Length > 0)
            {
                foreach(Collider potentialTargetCollider in colliders)
                {
                    if (potentialTargetCollider.CompareTag("Player"))
                    {
                        if (CanPotentialTargetBeSeen(potentialTargetCollider.transform))
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
            enemyMaster.CallEventEnmeyLostTarget();
            }
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
