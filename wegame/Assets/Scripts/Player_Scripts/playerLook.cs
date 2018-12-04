
using UnityEngine;

public class playerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform body; 
    private float xAxisStop;

    private void Awake()
    {
        LockCursor();
        xAxisStop = 0;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisStop += mouseY;
        if(xAxisStop < -90.0f)
        {
            xAxisStop = -90.0f;
            mouseY = 0.0f;
            StopXAxisRoation(90.0f);
        }
        else if(xAxisStop > 90.0f)
        {
            xAxisStop = 90.0f;
            mouseY = 0.0f;
            StopXAxisRoation(270.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        body.Rotate(Vector3.up, mouseX);
    }

    private void StopXAxisRoation(float value){
        Vector3 eRotation = transform.eulerAngles;
        eRotation.x = value;
        transform.eulerAngles = eRotation;
    }
}
