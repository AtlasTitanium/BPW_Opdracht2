using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IClickable {
	public void OnClick(){
		GetComponent<Animator>().SetBool("Open",!transform.GetComponent<Animator>().GetBool("Open"));
	}
	
	public void OnClick(GameObject HeldItem, GameObject clicker){
		Debug.Log("clicked on the door with " + HeldItem+ " by " + clicker);
	}
	
}
