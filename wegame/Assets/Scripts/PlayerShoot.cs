using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField] Camera cam;
    [SerializeField] LayerMask mask;
    [SerializeField] float shootRange = 100.0f;

	// Use this for initialization
	void Start () {
		if(cam == null)
        {
            Debug.LogError("PlayerShoot: No cammera Referenced");
            this.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        RaycastHit _hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, shootRange, mask))
        {
            Debug.Log("Hit: " + _hit.collider.name);
        }
    }
}
