using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, IClickable {
	public ItemType whatDoesTheClientWant;
	public void OnClick(){
		Debug.Log("the Customer has been clicked on");
	}

	public void OnClick(GameObject HeldItem,GameObject clicker){
		Items item = HeldItem.GetComponent<Items>();
		if(item.type == whatDoesTheClientWant){
			Debug.Log("the customer got what they wanted");
			Destroy(this.gameObject);
			clicker.GetComponent<PickupItems>().holdingItem.GetComponent<IGetable>().OnDrop(clicker.GetComponent<PickupItems>().playerCamera.gameObject);
			clicker.GetComponent<PickupItems>().holdingItem = null;
			Destroy(HeldItem);
		}
	}
}
