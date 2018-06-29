using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	void Start(){
		Cursor.visible = true;
	}
	public void StartGame(){
		Cursor.visible = false;
		Application.LoadLevel(1);
	}

	public void Quit(){
		Application.Quit();
	}
}
