using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RagdollActivation : MonoBehaviour {
    private Enemy_Master enemyMaster;
    private Collider myCollider;
    private Rigidbody myRigidbody;

    private void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += ActivateRagdoll;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= ActivateRagdoll;
    }

    void SetInitRef()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
        if(GetComponent<Collider>() != null)
        {
            myCollider = GetComponent<Collider>();
        }
        if(GetComponent<Rigidbody>() != null)
        {
            myRigidbody = GetComponent<Rigidbody>();
        }
    }
    void ActivateRagdoll()
    {
        if(myRigidbody != null)
        {
            myRigidbody.isKinematic = false;
            myRigidbody.useGravity = true;
        }

        if(myCollider != null)
        {
            myCollider.isTrigger = false;
            myCollider.enabled = true;
        }
    }
}
