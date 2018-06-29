using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpParent{
	public GameObject pickupPlace, givenObject;
	public PickUpParent(GameObject pickupPlace, GameObject givenObject){
		if(pickupPlace.transform.childCount <= 0){
			givenObject.transform.position = pickupPlace.transform.position;
			givenObject.transform.parent = pickupPlace.transform;
		}
	}

	public void Drop(GameObject pickupPlace, GameObject givenObject){
		if(pickupPlace.transform.childCount >= 1){
			givenObject.transform.parent = null;
		}
	}
}
