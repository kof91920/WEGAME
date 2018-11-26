using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {
    private Wall wallscript1;
    private Wall wallscript2;
    private Wall wallscript3;
    private Wall wallscript4;
    private Wall wallscript5;
    // Use this for initialization
    void Start () {
        SetInit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        wallscript1.setLayerToNotSoild();
        wallscript2.setLayerToNotSoild();
        wallscript3.setLayerToNotSoild();
        wallscript4.setLayerToNotSoild();
        wallscript5.setLayerToNotSoild();
    }

    void SetInit()
    {
        if (GameObject.Find("MCS Right Door") != null)
        {
            wallscript1 = GameObject.Find("MCS Right Door").GetComponent<Wall>();
            wallscript2 = GameObject.Find("MCS Left Door").GetComponent<Wall>();
            wallscript3 = GameObject.Find("Instructions 1").GetComponent<Wall>();
            wallscript4 = GameObject.Find("Instructions 2").GetComponent<Wall>();
            wallscript5 = GameObject.Find("Instructions 3").GetComponent<Wall>();
        }
        else
            Debug.Log("not find");
    }
}
