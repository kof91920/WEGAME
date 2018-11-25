using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
    [SerializeField] private string horInput;
    [SerializeField] private string verInput;
    [SerializeField] private float movementSpd;
    [SerializeField] private AnimationCurve fallOff;
    [SerializeField] private float jumpVal;
    [SerializeField] private KeyCode jumpKey;

    private CharacterController ccontrol;
    private bool jump;

    private void Awake()
    {
        ccontrol = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement(){
        float hInput = Input.GetAxis(horInput) * movementSpd * Time.deltaTime;
        float vInput = Input.GetAxis(verInput) * movementSpd * Time.deltaTime;

        Vector3 forward = transform.forward * vInput;
        Vector3 right = transform.right * hInput;

        ccontrol.SimpleMove(forward + right);
        jumpInput();
    }

    private void jumpInput(){
        if(Input.GetKeyDown(jumpKey) && !jump)
        {
            jump = true;
            StartCoroutine(jEvent());
        }
    }

    private IEnumerator jEvent(){
        float inAir = 0.0f;
        ccontrol.slopeLimit = 90.0f;
        do
        {
            float jforce = fallOff.Evaluate(inAir);
            ccontrol.Move(Vector3.up * jforce * jumpVal*Time.deltaTime);
            inAir += Time.deltaTime;
            yield return null; 
        } while (!ccontrol.isGrounded && ccontrol.collisionFlags!= CollisionFlags.Above);

        ccontrol.slopeLimit = 45.0f;
        jump = false;
    }

}
