using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chase : MonoBehaviour {

    private Transform myTransform;
    private UnityEngine.AI.NavMeshAgent myAgent;
    private Collider[] hitColliders;
    private float checkRate;
    private float nextCheck;
    private float detectionRadius = 80;
    public LayerMask detectionLayer;

    private void Start()
    {
        SetInitReference();
    }

    private void Update()
    {
        CheckPlayerRange();
    }

    void SetInitReference()
    {
        myTransform = transform;
        myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        checkRate = Random.Range(.8f, 1.2f);
    }

    void CheckPlayerRange()
    {
        if(Time.time > nextCheck && myAgent.enabled == true)
        {
            nextCheck = Time.time + checkRate;

            hitColliders = Physics.OverlapSphere(myTransform.position, detectionRadius, detectionLayer);

            if (hitColliders.Length > 0)
            {
                myAgent.SetDestination(hitColliders[0].transform.position);
            }
        }

       
    }

}
