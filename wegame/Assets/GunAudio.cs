using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Audio : MonoBehaviour {

	public AudioClip MusicClip;

	public AudioSource MusicSource;

	// Use this for initialization
	void Start () {
		MusicSource.clip = MusicClip;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
			MusicSource.Play();
	}
}