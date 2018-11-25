using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyController : MonoBehaviour
{

    // is the player taking damage
    bool isTakingDamage = true;

    // player rpg controller
    PlayerRpgController playerCtrl;

    void Awake()
    {
        playerCtrl = FindObjectOfType<PlayerRpgController>();

        if (playerCtrl == null)
        {
            Debug.LogError("The scene needs a PlayerRpgController object");
        }
    }

    void OnTriggerStay(Collider other)
    {
        // only take damage when the flag is true
        if (!isTakingDamage) return;

        // check we hit an enemy
        if (other.CompareTag("Enemy"))
        {
            print("enemy attack");

            // get the enemy
            EnemyController enemy = other.GetComponent<EnemyController>();

            // damage player health
            playerCtrl.damage(enemy.attack);

            // don't take damage for 1 second

            // set the flag to false
            isTakingDamage = false;

            Invoke("ActivateTakingDamage", 1);
        }
    }

    void ActivateTakingDamage()
    {
        isTakingDamage = true;
    }
}
