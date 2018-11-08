using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

    [SerializeField] private float movementSpd = 6f;
    [SerializeField] private float lookSensitivity = 4f;
    [SerializeField] private AnimationCurve fallOff;
    [SerializeField] private float jumpVal;
    [SerializeField] private KeyCode jumpKey;

    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody playerRB;
    private CharacterController ccontrol;
    private bool jump;

    private void Awake()
    {
        ccontrol = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        Rotation();
    }
    private void Rotation()
    {
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _playRotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
        playerRB.MoveRotation(playerRB.rotation * Quaternion.Euler(_playRotation));

        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _camRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;
        cam.transform.Rotate(-_camRotation);
    }

    private void Movement()
    {
        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");
        Vector3 _move = Vector3.zero;
        _move = (_xMov*transform.right+_zMov*transform.forward);
        _move = _move.normalized * movementSpd;
        playerRB.MovePosition(playerRB.position +_move * Time.fixedDeltaTime);

        
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
