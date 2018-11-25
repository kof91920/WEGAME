using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRpgController : MonoBehaviour {

    //walking spead
    public float walkSpeed;

    // health
    public float health = 100;

    // maximum health
    public float maxHealth = 100;

    // hand that will hold weapon
    public Transform weaponHand;

    // damage sphere
    public Renderer damageSphere;
    
    // player collectable controller
    PlayerCollectableCtrl playerCollectableCtr;

    // player free teleport controller
    PlayerFreeTeleportController playerFreeTeleportCtrl;

    // animator for the attacks
    Animator anim;

    // current weapon
    GameObject currWeapon;
    
    //Rigidbody component
    //Rigidbody rb;
    
    void Awake()
    {
        playerCollectableCtr = GetComponent<PlayerCollectableCtrl>();
        playerFreeTeleportCtrl = GetComponent<PlayerFreeTeleportController>();

        // get animator from the hand
        anim = weaponHand.GetComponent<Animator>();

        // Grab our components
        //rb = GetComponent<Rigidbody>();
        
        
        // refresh damage ui
        RefreshDamageMaterial();
    }

    void OnEnable()
    {
        playerCollectableCtr.OnCollect += HandleCollection;
    }

    void OnDisable()
    {
        playerCollectableCtr.OnCollect -= HandleCollection;
    }

    void HandleCollection(GameObject item)
    {
        switch(item.tag)
        {
            case "Health Kit":
                CollectHealth(item);
                Debug.Log("Health +10");
                break;

            case "Weapon":
                CollectWeapon(item);                
                break;
        }        
    }

    void CollectHealth(GameObject item)
    {
        // get item health
        float itemHealth = item.GetComponent<CollectableController>().GetProperty("health");

        // increase the player's health
        health = Mathf.Min(maxHealth, itemHealth + health);
        
        Debug.Log(health);
        // refresh damage
        RefreshDamageMaterial();

    }

    void CollectWeapon(GameObject item)
    {
        // check if we have a weapon
        if (currWeapon != null)
        {
            // place old weapon in position of the new weapon
            currWeapon.transform.position = item.transform.position;
            currWeapon.transform.rotation = item.transform.rotation;
            currWeapon.transform.parent = null;
        }

        //set position and rotation to that of the hand
        item.transform.position = weaponHand.position;
        item.transform.rotation = weaponHand.rotation;

        // make weapon a child of the hand
        item.transform.parent = weaponHand;

        // keep track of the new weapon
        currWeapon = item;
    }

    private void FixedUpdate()
    {
        //WalkHandler();
        //JumpHandler();
    }

    void Update()
    {
        // check if we have a weapon
        if(currWeapon != null && !playerCollectableCtr.IsSelecting() && !playerFreeTeleportCtrl.IsSelecting())
        {
            // check user input
            if(Input.GetButtonDown("Fire1")) 
            {
                // Oculus Rift Controller: Right A (Button.One)
                // X Box Controller: A, Button.One
                
                Attack();
            }            
        }
    }

    void Attack()
    {
        // trigger attack
        anim.SetTrigger("Attack");

        // set weapon as ready
        currWeapon.GetComponent<WeaponController>().SetReady(true);

        Invoke("InactivateWeapon", 0.3f);
    }

    void InactivateWeapon()
    {
        // set weapon as ready
        currWeapon.GetComponent<WeaponController>().SetReady(false);
    }

    void RefreshDamageMaterial()
    {
        // calculate transparency
        float alpha = (maxHealth - health) / maxHealth;

        // if our health is at 100%, disable sphere
        if(alpha == 0)
        {
            damageSphere.gameObject.SetActive(false);
        }
        // else, if it was disabled, enabled now
        else if(!damageSphere.gameObject.activeInHierarchy)
        {
            damageSphere.gameObject.SetActive(true);
        }

        // get current color
        Color currColor = damageSphere.sharedMaterial.color;
        currColor.a = alpha;

        // set the color of the damage sphere
        damageSphere.sharedMaterial.color = currColor;
    }

    public void damage(float amount)
    {
        // reduce health
        health -= amount;

        print("player health: " + health);

        // refresh damage
        RefreshDamageMaterial();

        // check death
        if (health <= 0)
        {
            print("game over");
            SceneManager.LoadScene("wegame_world");
        }

    }
    // Takes care of the walking logic
    void WalkHandler()
    {
        //float movementZ = speed * Time.deltaTime ;
        //transform.position += new Vector3(0, 0, );
        
        // Input on x (Horizontal)
        float hAxis = Input.GetAxis("Horizontal");

        // Input on z (Vertical)
        float vAxis = Input.GetAxis("Vertical");

        

        // Check that we are moving
        if(hAxis != 0 || vAxis != 0)
        {
            //anim.SetTrigger (jumpHash);
            
            // Movement vector
            Vector3 movement = new Vector3(hAxis * walkSpeed * Time.deltaTime, 0, vAxis * walkSpeed * Time.deltaTime);//movementZ);

            // Calculate the new position
            Vector3 newPos = transform.position + movement;

            // Move
            //rb.MovePosition(newPos);

            // Movement direction
            Vector3 direction = new Vector3(hAxis, 0, vAxis);

            // option 1: modify the transform
            //transform.forward = direction;

            // option 2: using our rigid body
            //rb.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            transform.position += new Vector3(0, 0, vAxis * walkSpeed * Time.deltaTime);// movementZ);
        }
    }

}
