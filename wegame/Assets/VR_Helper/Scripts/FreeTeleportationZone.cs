using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

[RequireComponent(typeof(VRInteractiveItem))]
public class FreeTeleportationZone : MonoBehaviour {

    VRInteractiveItem vrItem;
    VREyeRaycaster vrEyeRaycaster;
    PlayerFreeTeleportController playerCtrl;

    void Awake()
    {
        // get interactive vr item component
        vrItem = GetComponent<VRInteractiveItem>();

        // get vr eye rascaster
        vrEyeRaycaster = FindObjectOfType<VREyeRaycaster>();

        if(vrEyeRaycaster == null)
        {
            Debug.LogError("There needs to be a VR Eye Raster in the scene");
        }

        // get player free teleport controller
        playerCtrl = FindObjectOfType<PlayerFreeTeleportController>();

        if (playerCtrl == null)
        {
            Debug.LogError("There needs to be a PlayerFreeTeleportController in the scene");
        }
    }

    void OnEnable()
    {
        // subscribe to events
        vrEyeRaycaster.OnRaycasthit += HandleShowTarget;
        vrItem.OnOut += HandleOut;
        vrItem.OnClick += HandleClick;
    }

    void OnDisable()
    {
        // unsubscribe to events
        vrEyeRaycaster.OnRaycasthit -= HandleShowTarget;
        vrItem.OnOut -= HandleOut;
        vrItem.OnClick -= HandleClick;
    }

    void HandleClick()
    {
        playerCtrl.Teleport();
    }

    void HandleOut()
    {
        playerCtrl.HideTarget();
    }

    void HandleShowTarget(RaycastHit hit)
    {
        //check that we are actually looking at this object
        if (!vrItem.IsOver) return;

        playerCtrl.ShowTarget(hit.point);
    }

    
}
