using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    //rotation speed
    public float rotationSpeed = 100;
	
	// Update is called once per frame
	void Update () {
        // angle of rotation   v = d /t --> d = v * t
        float angleRot = rotationSpeed * Time.deltaTime;

        // rotate coin
        transform.Rotate(Vector3.up * angleRot, Space.World);
	}
}
