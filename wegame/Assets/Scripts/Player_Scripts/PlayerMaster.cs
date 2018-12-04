using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaster : MonoBehaviour {

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventHandsEmpty;

    public delegate void PlayerHealthEvenetHandler(int healthChange);
    public event PlayerHealthEvenetHandler EventPlayerHealthDecrease;
    public event PlayerHealthEvenetHandler EventPlayerHealthIncrease;

    public void CallEventPlayerDecrease(int dmg)
    {
        if (EventPlayerHealthDecrease != null)
        {
            EventPlayerHealthDecrease(dmg);
        }
    }


}
