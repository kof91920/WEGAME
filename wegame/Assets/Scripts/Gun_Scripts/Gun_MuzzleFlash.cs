using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_MuzzleFlash : MonoBehaviour {
    public ParticleSystem muzzleFlash;
    private Gun_Master gunMaster;

    private void OnEnable()
    {
        SetInitRef();
        gunMaster.EventPlayerInput += PlayMuzzleFlash;
    }
    private void OnDisable()
    {
        gunMaster.EventPlayerInput -= PlayMuzzleFlash;
    }
    void SetInitRef()
    {
        gunMaster = GetComponent<Gun_Master>();
    }

    void PlayMuzzleFlash()
    {
        if(muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
    }
}
