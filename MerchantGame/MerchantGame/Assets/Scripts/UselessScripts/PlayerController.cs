using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour{
    public float speed = 5f;
    public float Jumpspeed = 5f;
    public float lookSensitivity = 3f;
    public PlayerMotor motor;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update(){
        if (Input.GetKey(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None; 
        }
		if (Input.GetKey(KeyCode.Return)){
            Cursor.lockState = CursorLockMode.Locked; 
        }
        
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;
        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3 (0f, yRot, 0f) * lookSensitivity;
        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3 (xRot, 0f, 0f) * lookSensitivity;
        motor.RotateCamera(cameraRotation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            motor.Jump(Jumpspeed);
        }
    }
}