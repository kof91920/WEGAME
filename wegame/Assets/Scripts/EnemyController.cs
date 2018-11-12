using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    // health points
    public float health = 30;

    // damage it causes
    public float attack = 10;

    // navmesh component
    NavMeshAgent navmesh;
      
    void Awake()
    {
        // get component
        navmesh = GetComponent<NavMeshAgent>();

        InvokeRepeating("SetDestination", 0, 0.2f);
    }

    void SetDestination()
    {
        // set the enemy destination
        navmesh.SetDestination(Camera.main.transform.position);
    }

    public void damage(float amount)
    {
        // reduce health
        health -= amount;

        // check death
        if (health <= 0)
        {
            Destroy(gameObject);
        }
            
    }
}
