using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class PlayerFreeTeleportController : MonoBehaviour {

    // teleportation target game object
    public GameObject target;

    // max teleportation distance
    public float maxDistance;

    // show arc
    public bool showArc;

    // number of points in the arc
    public int numArcPoints;

    // origin of the arc
    public Transform arcOrigin;

    // reticle
    Reticle reticle;

    // keep track of whether we are showing or not
    bool isShowing;

    // line renderer
    LineRenderer lineRend;

    //points of the arc
    Vector3[] arcPoints;

    void Awake()
    {
        HideTarget();

        // find reticle
        reticle = FindObjectOfType<Reticle>();

        // get the line renderer
        if (showArc)
        {
            lineRend = target.GetComponent<LineRenderer>();

            if(lineRend == null)
            {
                Debug.LogError("Make sure the target has a Line Renderer");
            }

            // set number of points
            lineRend.positionCount = numArcPoints;

            // points vector
            arcPoints = new Vector3[numArcPoints];
        }
    }

    // hide the target
    public void HideTarget()
    {
        target.SetActive(false);

        if(reticle != null)
        {
            reticle.Show();
        }

        // update our flag
        isShowing = false;
    }

    // show target
    public void ShowTarget(Vector3 position)
    {
        // check distance
        if (Vector3.Distance(position, transform.position) <= maxDistance)
        {
            //if the target is not active, activate it!
            if (!target.activeInHierarchy)
            {
                target.SetActive(true);

                if (reticle != null)
                {
                    reticle.Hide();
                }
            }
            // set the teleport target to the position we are pointing at
            target.transform.position = position;

            //update flag
            isShowing = true;

            // show ray
            if (showArc)
            {
                DrawRay();
            }
            
        }
        //if we were showing the reticle, but now it's too far way
        // hide
        else if(isShowing)
        {
            HideTarget();
        }
    }

    //teleportation
    public void Teleport()
    {
        if(isShowing)
        {
            // player position will be equal to the target position
            transform.position = target.transform.position;
            HideTarget();
        }
    }

    // draw ray
    void DrawRay()
    {
        // starting position of the arc
        Vector3 startPoint = arcOrigin.position;

        // ending position
        Vector3 endPoint = target.transform.position;

        // arc effect
        float arcY;

        // create all the points until the end
        for(int i = 0; i < numArcPoints; i++ )
        {
            // arc effect
            arcY = Mathf.Sin((float)i / numArcPoints * Mathf.PI) / 2;

            // create point
            arcPoints[i] = Vector3.Lerp(startPoint, endPoint, (float)i / numArcPoints);
            arcPoints[i].y += arcY;
        }

        // assign points to the line renderer
        lineRend.SetPositions(arcPoints);
    }

    // return whether we are selecting or not
    public bool IsSelecting()
    {
        return isShowing;
    }
}
