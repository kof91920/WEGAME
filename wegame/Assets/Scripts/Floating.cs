using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {
    public float amplitude = 0.5f;
    public float rotateSpeed = 0.5f;
    public Vector3 pos;
    // Update is called once per frame
    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));

        Vector3 new_pos = pos;
        new_pos.y += Mathf.Sin(Time.fixedTime * Mathf.PI) * amplitude;
        transform.position = new_pos;
    }
}
