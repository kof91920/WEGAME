using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Shot : MonoBehaviour
{
    private Gun_Master gunMaster;
    private Transform myTransform;
    private Transform camTransform;
    private RaycastHit hit;
    public float range = 400;
    private float offsetFactor = 7;
    private Vector3 startPosition;

    private void OnEnable()
    {
        SetInitRef();
        gunMaster.EventPlayerInput += OpenFire;
        gunMaster.EventSpeedCaputred += SetStartOfShootingPosition;
    }
    private void OnDisable()
    {
        gunMaster.EventPlayerInput -= OpenFire;
        gunMaster.EventSpeedCaputred -= SetStartOfShootingPosition;
    }
    void SetInitRef()
    {
        gunMaster = GetComponent<Gun_Master>();
        myTransform = transform;
        camTransform = myTransform.parent;

    }
    void OpenFire()
    {
       // Debug.Log("Open Fire called");
        if(Physics.Raycast(camTransform.TransformPoint(startPosition),camTransform.forward,out hit, range))
        {
            gunMaster.CallEventShotDefault(hit.point, hit.transform);

            if (hit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Shot Enemy");
                gunMaster.CallEventShotEnemy(hit.point, hit.transform);
            }

        }
    }
    void SetStartOfShootingPosition(float playerSpeed)
    {
        float offset = playerSpeed / offsetFactor;
        startPosition = new Vector3 (Random.Range(-offset, offset), Random.Range(-offset, offset), 1);
    }
}


