using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallDamage : MonoBehaviour {
    private Transform mytransform;
    private Collider[] hitColliders;
    public float hitRadius;
    public float Power;
    public LayerMask layer;
    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        RadiusWork(collision.contacts[0].point);
        Destroy(gameObject);
    }

    void RadiusWork(Vector3 hitPoint)
    {
        hitColliders = Physics.OverlapSphere(hitPoint, hitRadius);

        foreach(Collider i in hitColliders)
        {
            if(i.GetComponent<UnityEngine.AI.NavMeshAgent>()!= null)
            {
                i.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            }

            if(i.GetComponent<Rigidbody>() != null)
            {
                i.GetComponent<Rigidbody>().isKinematic = false;
                i.GetComponent<Rigidbody>().AddExplosionForce(Power, hitPoint, hitRadius, 2, ForceMode.Impulse);
            }
        }
    }
}
