using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public Text counterText;

	public float seconds, minutes;
	
	// Use this for initialization
	void Start ()
	{
		counterText = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update ()
	{

		minutes = (int) (Time.time / 60f);
		seconds = (int) (Time.time % 60f);
		counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

	}

	public void Reset()
	{
		seconds = 0f;
		minutes = 0f;
	}


}
