using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowBall : MonoBehaviour {

    public GameObject SnowBall;
    private Transform mytransform;
    public float force;
	// Use this for initialization
	void Start () {
        SetInit();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            throwSnow();
        }
	}

    void SetInit()
    {
        mytransform = transform;
    }

    void throwSnow()
    {
        GameObject ball = (GameObject)Instantiate(SnowBall, mytransform.TransformPoint(0, 1, 2.5f), mytransform.rotation);
        ball.GetComponent<Rigidbody>().AddForce(mytransform.forward * force, ForceMode.Impulse);
        Destroy(ball, 10);
    }
}
