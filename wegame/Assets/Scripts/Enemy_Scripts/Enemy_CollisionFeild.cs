using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CollisionFeild : MonoBehaviour {
    private Enemy_Master enemyMaster;
    private Rigidbody ridgeBodyStrikingMe;
    private int damageToApply;
    public float massRequirement = 50;
    public float speedRequirement = 5;
    private float damageFactor = 0.1f;

    private void OnEnable()
    {
        SetInitRef();
        enemyMaster.EventEnemyDie += DisableThis;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
            ridgeBodyStrikingMe = other.GetComponent<Rigidbody>();

            if(ridgeBodyStrikingMe.mass >= massRequirement &&
                ridgeBodyStrikingMe.velocity.sqrMagnitude > speedRequirement * speedRequirement)
            {
                damageToApply = (int)(damageFactor * ridgeBodyStrikingMe.mass * ridgeBodyStrikingMe.velocity.magnitude);
                enemyMaster.CallEventEnemyDeductHealth(damageToApply);
            }
        }
    }
    void SetInitRef()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
    }

    void DisableThis()
    {
        gameObject.SetActive(false);
    }
}
