using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // speed of the enemy
    public float speed = 3;

    // range of movement Y
    public float rangeY = 2;

    // initial position
    Vector3 initialPos;

    // direction
    int direction = 1;

	// Use this for initialization
	void Start () {
        // save initial position
        initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        /*
        // factor
        float factor = 1;

        // check whether we are going up or down
        if(direction == -1)
        {
            factor = 1.2f;
        }
        */

        // ternary operator
        float factor = direction == -1 ? 2f : 1;

        // how much are we moving?
        // Time.deltaTime, speed
        float movementY = factor * speed * Time.deltaTime * direction;

        // new position y
        float newY = transform.position.y + movementY;

        // checking whether we've left our range
        if(Mathf.Abs(newY - initialPos.y) > rangeY)
        {
            direction *= -1;
        }
        // if we can move further, let's move further!
        else
        {
            transform.position += new Vector3(0, movementY, 0);
        }
    }
}
