using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TakeDamage : MonoBehaviour {
    private Enemy_Master enemyMaster;
    public int damageMultiplier = 1;
    public bool shouldRemoveColider;

    private void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += RemoveThis;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= RemoveThis;
    }

    void SetInitRef()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
    }

    public void ProcessDamage(int damage)
    {
        int damageToApply = damage * damageMultiplier;
        enemyMaster.CallEventEnemyDeductHealth(damageToApply);
    }
    void RemoveThis()
    {
        if (shouldRemoveColider)
        {
            if(GetComponent<Collider>() != null)
            {
                Destroy(GetComponent<Collider>());
            }
            if(GetComponent<Rigidbody>()!= null)
            {
                Destroy(GetComponent<Rigidbody>());
            }
        }

    }
}
