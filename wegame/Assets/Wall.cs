using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setLayerToNotSoild()
    {
        MeshRenderer m = GetComponent<MeshRenderer>();
        m.enabled = false;
        gameObject.SetActive(false);
    }

}
