using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;


[RequireComponent(typeof(VRInteractiveItem))]
public class VR2DButtonController : MonoBehaviour
{

    //vr interactive item component
    VRInteractiveItem vrInteractive;

    //2d canvas button
    Button button;

    void Awake()
    {
        //grabbing the vr interactive component
        vrInteractive = GetComponent<VRInteractiveItem>();

        //get button
        button = GetComponentInChildren<Button>();
    }

    void OnEnable()
    {
        vrInteractive.OnClick += button.onClick.Invoke;
    }

    void OnDisable()
    {
        vrInteractive.OnClick -= button.onClick.Invoke;
    }

}
