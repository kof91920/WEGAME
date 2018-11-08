using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectableCtrl : MonoBehaviour {

    //max distance at which you can collect
    public float maxDistance;

    //flag of whether we are selecting or not
    bool isSelecting = false;

    //event for when an item is collected
    //1)delegate
    public delegate void OnCollectedEventHandler(GameObject item);

    //2)event
    public event OnCollectedEventHandler OnCollect;

    // called when collecting an item
    public void Collect(GameObject item)
    {
        if(OnCollect != null)
        {
            // trigger our event
            OnCollect(item);
        }

        // set selecting flag to false
        isSelecting = false;
    }

    // called when selecting an item
    public void SelectionOver()
    {
        isSelecting = true;
    }

    // called when unselecting an item
    public void SelectionOut()
    {
        isSelecting = false;
    }

    // return whether we are selecting or not
    public bool IsSelecting()
    {
        return isSelecting;
    }

    public void SetSelected(bool val)
    {
        isSelecting = val;
    }
}
