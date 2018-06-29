using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {
	public GameObject Player;
	public GameObject menuObject;
	public GameObject menuCamera;
	private bool menuActive = false;
	void Update () {
		if(Input.GetButtonDown("Cancel")){
			Cursor.lockState = CursorLockMode.None;
			menuActive = !menuActive;
		}
		Player.SetActive(!menuActive);
		menuObject.SetActive(menuActive);
		menuCamera.SetActive(menuActive);
		if(!menuActive){
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	public void Return(){
		menuActive = !menuActive;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void Quit(){
		Application.LoadLevel(0);
	}
}
