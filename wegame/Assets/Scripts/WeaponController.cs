using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollectableController))]
public class WeaponController : MonoBehaviour {

    
    bool isReady = false;

    CollectableController collectable;

    public void SetReady(bool value)
    {
        isReady = value;
    }

    void Awake()
    {
        collectable = GetComponent<CollectableController>();
    }
    
    void OnTriggerStay(Collider other)
    {
        // weapon is being swinged
        if (!isReady) return;

        // check we hit an enemy
        if(other.CompareTag("Enemy"))
        {
            // get the enemy
            EnemyController enemy = other.GetComponent<EnemyController>();

            // damage the enemy
            enemy.damage(collectable.GetProperty("attack"));

            // only hit once per swing
            isReady = false;
        }
    }
}
