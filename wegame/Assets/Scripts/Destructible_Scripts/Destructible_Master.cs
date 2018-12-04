using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_Master : MonoBehaviour {
    public delegate void HealthEventHandler(int health);
    public event HealthEventHandler EventDeductHealth;

    public delegate void GernaralEventHandler();
    public event GernaralEventHandler EventDestoryMe;
    public event GernaralEventHandler EventHealthLow;
    
    public void CallEventDeductHealth(int healthToDeduct)
    {
        if(EventDeductHealth != null)
        {
            EventDeductHealth(healthToDeduct);
        }
    }

    public void CallEventDestroyMe()
    {
        if(EventDestoryMe != null)
        {
            EventDestoryMe();
        }
    }

    public void CallEventHealthLow()
    {
        if(EventHealthLow != null)
        {
            EventHealthLow();
        }
    }
}
