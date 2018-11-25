using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_TakeDamage : MonoBehaviour {

    private Destructible_Master destrutibleMaster;

    private void Start()
    {
        SetInitRef();
    }
    void SetInitRef()
    {
        destrutibleMaster = GetComponent<Destructible_Master>();
  
    }
    
    public void ProcessDamage(int damage)
    {
        destrutibleMaster.CallEventDeductHealth(damage);
    }
}
