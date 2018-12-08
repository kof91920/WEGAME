using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Master : MonoBehaviour {

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventPlayerInput;
    public event GeneralEventHandler EventGunNotUsable;
    public event GeneralEventHandler EvenetRequestReload;
    public event GeneralEventHandler EventRequestGunReset;
    public event GeneralEventHandler EventToggleBurstFire;


    public delegate void GunHitEventHanlder(Vector3 hitpos, Transform hitTransform);
    public event GunHitEventHanlder EventShotDefault;
    public event GunHitEventHanlder EventShotEnemy;

    public delegate void GunCrosshairEventHandler(float speed);
    public event GunCrosshairEventHandler EventSpeedCaputred;

    public delegate void GunAmmoEventHandler(int currentAmmo, int carriedAmmo);
    public event GunAmmoEventHandler EventAmmoChanged;

    public bool isGunloaded;
    public bool isReloading;

    public AudioSource source; //AudioSource for Gunshot
    public AudioClip gunshot; //audioclip

    public void CallEventPlayerInput(){
        if (EventPlayerInput != null){
            EventPlayerInput();
            if(!source.isPlaying){ // Plays gun Audio
                float vol = Random.Range(.8f, 1.0f);
                source.pitch = Random.Range(.8f, 1.1f);
                source.PlayOneShot(gunshot, vol); // play
                
            }
        }
    }
    public void CallEventGunNotUsable()
    {
        if (EventGunNotUsable != null)
        {
            EventGunNotUsable();
        }
    }
    public void CallEvenetRequestReload()
    {
        if (EvenetRequestReload != null)
        {
            EvenetRequestReload();
        }
    }

    public void CallEvenetRequestGunReset()
    {
        if (EventRequestGunReset != null)
        {
            EventRequestGunReset();
        }
    }

    public void CallEventToggleBurstFire()
    {
        if(EventToggleBurstFire != null)
        {
            EventToggleBurstFire();
        }
    }

    public void CallEventShotDefault(Vector3 hitpos, Transform hitTrans)
    {
        if (EventShotDefault != null)
        {
            EventShotDefault(hitpos,hitTrans);
        }
    }

    public void CallEventShotEnemy(Vector3 hitpos, Transform hitTrans)
    {
        if (EventShotEnemy != null)
        {
            EventShotEnemy(hitpos,hitTrans);
        }
    }
    public void CallEventSpeedCaputred(float spd)
    {
        if(EventSpeedCaputred != null)
        {
            EventSpeedCaputred(spd);
        }
    }

    public void CallEventAmmoChanged(int curAmmo, int carAmmo)
    {
        if (EventAmmoChanged != null)
        {
            EventAmmoChanged(curAmmo, carAmmo);
        }
    }
}
