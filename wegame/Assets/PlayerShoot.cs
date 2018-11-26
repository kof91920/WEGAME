using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private float fireRate = .3f;
    private float nextFire;
    private RaycastHit hit;
    private float range = 8000;
    private Transform myTransform;

    private void Start()
    {
        SetInit();
    }

    private void Update()
    {
        CheckForInput();
    }

    void SetInit()
    {
        myTransform = transform;
    }

    void CheckForInput()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Debug.DrawRay(myTransform.TransformPoint(0,0,10), myTransform.forward, Color.red, 3);
            if(Physics.Raycast(myTransform.TransformPoint(0,0,10), myTransform.forward,out hit, range))
            {
                if(hit.transform.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy"+hit.transform.name);
                }
                else
                {
                    Debug.Log("not enemy" + hit.transform.name);
                }
                
            }

            nextFire = Time.time + fireRate; 
            
        }
    }
}
