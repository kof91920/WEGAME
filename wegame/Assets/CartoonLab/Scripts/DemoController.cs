using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoController : MonoBehaviour {

    public Transform characters;
    private void Start()
    {
        foreach (Transform character in characters)
        {
            character.GetComponent<Animator>().SetBool("isIdle", false);
        }
    }

    public void toggleChange(bool toggle)
    {
        foreach (Transform character in characters)
        {
            character.GetComponent<Animator>().SetBool("isIdle", true);
        }
    }
}
