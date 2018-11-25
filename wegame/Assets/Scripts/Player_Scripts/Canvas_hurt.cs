using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_hurt : MonoBehaviour {
    public GameObject hurtCanvas;
    private PlayerMaster playerMaster;
    private float secondsTillHide = 2;

    private void OnEnable()
    {
        SetInitRef();
        playerMaster.EventPlayerHealthDecrease += TurnOnHurtEffect;
    }

    private void OnDisable()
    {
        playerMaster.EventPlayerHealthDecrease -= TurnOnHurtEffect;
    }
 
    void SetInitRef()
    {
        playerMaster = GetComponent<PlayerMaster>();
    }

    void TurnOnHurtEffect(int change)
    {
        if(hurtCanvas != null)
        {
            StopAllCoroutines();
            hurtCanvas.SetActive(true);
            StartCoroutine(ResetHurtCanvas());
        }
    }

    IEnumerator ResetHurtCanvas()
    {
        yield return new WaitForSeconds(secondsTillHide);
        hurtCanvas.SetActive(false);
    }

}
