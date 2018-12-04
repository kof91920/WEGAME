using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_HitEffects : MonoBehaviour {
    private Gun_Master gunMaster;
    public GameObject defaultHitEffect;
    public GameObject enemyHitEffect;

    private void OnEnable()
    {
        SetInitRef();
        gunMaster.EventShotDefault += SpawnDefaultHitEffect;
        gunMaster.EventShotEnemy += SpawnEnemyHitEffect;
    }

    private void OnDisable()
    {
        gunMaster.EventShotDefault -= SpawnDefaultHitEffect;
        gunMaster.EventShotEnemy -= SpawnEnemyHitEffect;
    }
    private void SetInitRef()
    {
        gunMaster = GetComponent<Gun_Master>();
    }
    void SpawnDefaultHitEffect(Vector3 hitPos, Transform hitTrans)
    {
        if (defaultHitEffect != null)
        {
            Instantiate(defaultHitEffect, hitPos, Quaternion.identity);
        }

    }
    void SpawnEnemyHitEffect(Vector3 hitPos, Transform hitTrans)
    {
        if(enemyHitEffect != null)
        {
            Instantiate(enemyHitEffect, hitPos, Quaternion.identity);
        }
    }
}
