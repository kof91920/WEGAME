using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Movements : MonoBehaviour
{
	// rigid body componenet
	private Rigidbody rb;

	// animator
	private Animator anim;

	// walking speed
	public float speed = 50.0f;
		
	// angular speed;
	public float angularSpeed = 1.0f;

	enum State
	{
		idle,
		attacking,
		dead
	};
	
	// player
	private playerMove player;

	// distance at which zombie will chase the player
	public float chasingDistance = 10;
	private State currentState = State.idle;

// Use this for initialization
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		
		// get the player
		player = FindObjectOfType<playerMove>();
		
		InvokeRepeating("LookForPlayer", 0, 0.5f);
		
	}


	// Update is called once per frame
	void Update () {
		
		
	}

	private void FixedUpdate()
	{
		// only chase if we are attacking
		if (currentState != State.attacking) return;

		Vector3 dir = player.transform.position - transform.position;
		dir.Normalize();
		
		// velocity
		Vector3 vel = dir * speed;
		
		// set rb velocity;
		rb.velocity = vel;
		
		//transform.LookAt(player.transform.position);
		
		// rotation with angular speed
		
		// "flat difference" between player and the enemy
		Vector3 flatDiff = player.transform.position - transform.position;
		flatDiff.y = 0;
		
		// rotation needed, in Quartenio
		Quaternion targetRotation = Quaternion.LookRotation(flatDiff, Vector3.up);
		
		// angular rotation velocity vector
		Vector3 eularAngleVelocity = new Vector3(0, angularSpeed, 0);
		
		// delta rotation distance = velocity * time
		Quaternion deltaRotation = Quaternion.Euler(eularAngleVelocity * Time.fixedDeltaTime);
		
		// rigid body rotation
		rb.MoveRotation(targetRotation*deltaRotation);


	}

	void LookForPlayer()
	{
		// only look if the zombie is idle
		if (currentState != State.idle) return;
		
		// check distance
		if (Vector3.Distance(player.transform.position, transform.position) <= chasingDistance)
		{
			// change state to attacking
			currentState = State.attacking;
			
			// activate attack animation
			anim.SetBool("sawPlayer", true);
			
			// cancel the looking for the invakation
			CancelInvoke();
		}
			
	}

	private void OnTriggerEnter(Collider other)
	{
		// check if a bullet has hit us
		if (other.CompareTag("Bullet"))
		{
			// change the state to dead
			currentState = State.dead;
			
			// disable collider -> transparent to us
			GetComponent<Collider>().enabled = false;
			rb.isKinematic = true;
			
		}
	}
}
