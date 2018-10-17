using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFixedTeleportationController : MonoBehaviour
{
    // current teleportation pod
    public FixedTeleportationPodController currentPod;

    // teleportation range
    public float range;

    // refresh rate (seconds)
    public float refreshRate = 0;

    // list that contains all the pods
    List<GameObject> pods;
    
    void Start()
    {
        if(refreshRate > 0)
        {
            InvokeRepeating("RefreshPods", 0, refreshRate);
        }
        else
        {
            // refresh the pods
            RefreshPods();
        }            
    }

    // move the player to the teleportation pod
    public void Teleport(FixedTeleportationPodController pod)
    {
        // teleportation pod position
        Vector3 podPos = pod.gameObject.transform.position;

        // calculate height difference between current the new pod
        float diffY = podPos.y - currentPod.gameObject.transform.position.y;

        // place the player in the position of the pod
        transform.position = new Vector3(podPos.x, transform.position.y + diffY, podPos.z);

        // save new "currentPod"
        currentPod = pod;

        // make the parent of the pod, parent of the player
        transform.parent = currentPod.gameObject.transform.parent;

        // refresh the pods
        RefreshPods();            
    }

    // show only the pods that you can move towards
    void RefreshPods()
    {
        // transform of the pod
        Transform pod;

        // find all the pods            
        for(int i = 0; i < pods.Count; i++)
        {
            // assign pod
            pod = pods[i].transform;

            // check distance
            if (Vector3.Distance(pod.position, transform.position) <= range)
            {
                pod.gameObject.SetActive(true);
            }
            else
            {
                // deactivate all pods
                pod.gameObject.SetActive(false);
            }
        }            
        
        // deactivate the current pod
        currentPod.gameObject.SetActive(false);
    }

    // adds a pod to our list
    public void AddTeleportationPod(GameObject pod)
    {   
        if(pods == null)
            pods = new List<GameObject>();

        pods.Add(pod);
    }

   
}

