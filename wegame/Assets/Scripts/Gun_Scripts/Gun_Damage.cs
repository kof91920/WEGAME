using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Damage : MonoBehaviour {
    private Gun_Master gunMaster;
    public int damage = 10;

    private void OnEnable()
    {
        SetInitRef();
        gunMaster.EventShotEnemy += ApplyDamage;
    }
    private void OnDisable()
    {
        gunMaster.EventShotEnemy -= ApplyDamage;
    }
    void SetInitRef()
    {
        gunMaster = GetComponent<Gun_Master>();
    }
    void ApplyDamage(Vector3 hiPos, Transform hitTrans) {
        if (hitTrans.GetComponent<Enemy_TakeDamage>()!=null)
        {
            hitTrans.GetComponent<Enemy_TakeDamage>().ProcessDamage(damage);
        }
    }
}
