using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {
    private RaycastHit hit;
    public LayerMask detectionLayer;
    private float range = 5;
    private float checkRate = 0.5f;
    private float nextCheck;
    private Transform mytransform;

    private void Start()
    {
        SetInit();
    }

    private void Update()
    {
        DetectItems();
    }

    void SetInit()
    {
        mytransform = transform;
    }

    void DetectItems()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            if(Physics.Raycast(mytransform.position,mytransform.forward,out hit, range, detectionLayer))
            {
                Debug.Log(hit.transform.name + "is an item");
            }
        }
    }
}
