using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Input : MonoBehaviour {
    private Gun_Master gunMaster;
    private float nextAttack;
    public float attackRate = 0.5f;
    private Transform myTransform;
    public bool isAutomatic;
    public bool hasBurstFire;
    private bool isBurstFireActive;
    public string attackButtonName;
    public string reloadButtonName;
    public string burstFireButtonName;

    private void Start()
    {
        SetInitRef();
    }
    private void Update()
    {
        CheckIfWeaponShouldAttack();
        CheckForBurstFireToggle();
        CheckForReloadRequest();
    }
    void SetInitRef()
    {
        gunMaster = GetComponent<Gun_Master>();
        myTransform = transform;
        gunMaster.isGunloaded = true;
    }
    void CheckIfWeaponShouldAttack()
    {
        if (Time.time > nextAttack && Time.timeScale > 0 &&
            myTransform.root.CompareTag("Player"))
        {
            if (isAutomatic && !isBurstFireActive)
            {
                if (Input.GetButton(attackButtonName))
                {
                    Debug.Log("FullAuto");
                    AttemptAttack();
                }
            }

            else if (isAutomatic && isBurstFireActive)
            {
                if (Input.GetButtonDown(attackButtonName))
                {
                    Debug.Log("Burst");
                    StartCoroutine(RunBurstFire());
                }
            }
            else if (!isAutomatic)
            {
                if (Input.GetButtonDown(attackButtonName))
                {
                    AttemptAttack();
                }
            }
        }
    }
    void AttemptAttack()
    {
        nextAttack = Time.time + attackRate;
        if (gunMaster.isGunloaded)
        {
            //Debug.Log("Shooting");
            gunMaster.CallEventPlayerInput();
        }
        else
        {
            gunMaster.CallEventGunNotUsable();
        }
    }

    void CheckForReloadRequest()
    {
        if(Input.GetButtonDown(reloadButtonName) && Time.timeScale >0 &&
            myTransform.root.CompareTag("Player"))
        {
            gunMaster.CallEvenetRequestReload();
        }
    }
    void CheckForBurstFireToggle()
    {
        if (Input.GetButtonDown(burstFireButtonName) && Time.timeScale > 0 &&
    myTransform.root.CompareTag("Player"))
        {
            Debug.Log("Burst Fire Toggled");
            isBurstFireActive = !isBurstFireActive;
            gunMaster.CallEventToggleBurstFire();
        }
    }
    IEnumerator RunBurstFire()
    {
        AttemptAttack();
        yield return new WaitForSeconds(attackRate);
        AttemptAttack();
        yield return new WaitForSeconds(attackRate);
        AttemptAttack();
    }
}

