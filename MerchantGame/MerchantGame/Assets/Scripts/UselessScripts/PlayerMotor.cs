using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
	public Camera cam;
	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;
	private Rigidbody rb;
	private bool isGrounded;
	public int viewRange;
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	public void Move(Vector3 velocities){
		velocity = velocities;
	}
	public void Rotate(Vector3 rotationes){
		rotation = rotationes;
	}
	public void RotateCamera(Vector3 cameraRotationes){
		cameraRotation = cameraRotationes;
	}
	void Update() {
		if (velocity != Vector3.zero){
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		if (cam != null){
			cam.transform.Rotate(-cameraRotation);
			//Debug.Log("cam x rotation: " + cam.transform.localEulerAngles.x);
			if(cam.transform.localEulerAngles.x < 360 - viewRange && cam.transform.localEulerAngles.x > 350 - viewRange )
			{
				cam.transform.localEulerAngles = new Vector3(360 - viewRange, 0, 0);
			}

			if(cam.transform.localEulerAngles.x > viewRange && cam.transform.localEulerAngles.x < viewRange + 10)
			{
				cam.transform.localEulerAngles = new Vector3(viewRange, 0, 0);
			} 
		}
		//cameraRotation = new Vector3(Mathf.Clamp(cam.transform.eulerAngles.x, downRange, upRange),cameraRotation.y,cameraRotation.z);
		//cam.transform.Rotate(-cameraRotation);

		/*
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		cam.transform.Rotate(-cameraRotation);

		Debug.Log(cam.transform.eulerAngles.x);
		//Debug.Log("cam x rotation: " + cam.transform.localEulerAngles.x);
		if(cam.transform.eulerAngles.x >= 340 || cam.transform.eulerAngles.x <= 20){	
			
			return;
		}
		if(cam.transform.eulerAngles.x > 20){
			cam.transform.eulerAngles = new Vector3(19.99f, cam.transform.eulerAngles.y, 0);
			return;
		}
		if(cam.transform.eulerAngles.x < 340){
			cam.transform.eulerAngles = new Vector3(340.01f, cam.transform.eulerAngles.y, 0);
		}
		*/
	}

	public void Jump(float jumpSpeed){
		RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit)){
			if(hit.distance < 1.2){
				rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
			}
		}
	}
}
