using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {
    private Wall wallscript1;
    private Wall wallscript2;

    // Use this for initialization
    void Start () {
        SetInit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi Trigger Enter");
        wallscript1.setLayerToNotSoild();
        wallscript2.setLayerToNotSoild();
        

    }

    void SetInit()
    {
        if (GameObject.Find("MCS Right Door") != null)
        {
            print("1");
            wallscript1 = GameObject.Find("MCS Right Door").GetComponent<Wall>();
            wallscript2 = GameObject.Find("MCS Left Door").GetComponent<Wall>();
        }
        else
            Debug.Log("not find");
    }
}
