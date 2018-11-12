using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaster : MonoBehaviour {

    public delegate void GeneralEvent();
    public event GeneralEvent myGeneralEvent;

    public void CallGeneralEvent()
    {

        if(myGeneralEvent != null)
        {
            myGeneralEvent();
        }
    }

}
