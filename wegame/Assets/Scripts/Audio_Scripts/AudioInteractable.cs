using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteractable : MonoBehaviour {

	public List<AudioClip> clips = new List<AudioClip>();
	private bool exited = false;
	private bool alreadyPlayed = false;
	//private int count = 0;
	// Use this for initialization
	
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator OnTriggerEnter(Collider other)
	{	
		AudioSource audio = GetComponent<AudioSource>();
		//exited = false;
		if(other.tag == "Player" && alreadyPlayed == false)
		{
			Debug.Log("Player Entered");
			alreadyPlayed = true;
			for (int i=0; i < clips.Count; i++)
			{
				audio.clip = clips[i];
				audio.Play(); 
				yield return new WaitForSeconds(audio.clip.length);

				if(exited == true)
				{
					break;
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{	
		Debug.Log("Exited Trigger");
		exited = true;
	}
}
