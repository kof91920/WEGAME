using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;


[RequireComponent(typeof(VRInteractiveItem))]
public class FixedTeleportationPodController : MonoBehaviour
{

    // vr interactive item components
    VRInteractiveItem vrInteractive;

    // point light
    Light podLight;

    // player fixed teleport controller
    PlayerFixedTeleportationController playerTeleport;

    void Awake()
    {
        // grabbing the vr interactive item component
        vrInteractive = GetComponent<VRInteractiveItem>();

        // grab the light from within the children objects
        //podLight = transform.GetChild(0).gameObject.GetComponent<Light>();
        podLight = GetComponentInChildren<Light>();

        //disable light at the beginning
        podLight.gameObject.SetActive(false);

        // grab player fixed teleportation controller
        playerTeleport = FindObjectOfType<PlayerFixedTeleportationController>();

        if(playerTeleport == null)
        {
            Debug.LogError("Remember to add the PlayerFixedTeleportationController component to your player");
        }

        // add the current object to the list
        playerTeleport.AddTeleportationPod(gameObject);
    }

    void OnEnable()
    {
        // add events
        vrInteractive.OnOver += Highlight;
        vrInteractive.OnOut += Unhighlight;
        vrInteractive.OnClick += ClickPod;
    }

    void OnDisable()
    {
        // add events
        vrInteractive.OnOver -= Highlight;
        vrInteractive.OnOut -= Unhighlight;
        vrInteractive.OnClick -= ClickPod;
    }

    void ClickPod()
    {
        print("Now teleport!");
        playerTeleport.Teleport(this);
    }

    void Unhighlight()
    {
        podLight.gameObject.SetActive(false);
    }

    void Highlight()
    {
        podLight.gameObject.SetActive(true);
    }

    // draw gizmos when the object is selected
    void OnDrawGizmosSelected()
    {
        playerTeleport = FindObjectOfType<PlayerFixedTeleportationController>();

        //draw a sphere that shows the teleportation range
        float radius = playerTeleport.range;

        //color
        Gizmos.color = Color.white;

        //draw the sphere
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
