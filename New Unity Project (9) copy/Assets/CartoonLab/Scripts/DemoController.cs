using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoController : MonoBehaviour {

    public Transform characters;


    public void toggleChange(bool toggle)
    {
        foreach (Transform character in characters)
        {
            character.GetComponent<Animator>().SetBool("isIdle", !toggle);
        }
    }
}
