using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType{Sword,Hammer,Shield}
public class Items : MonoBehaviour , IGetable{
	public ItemType type;
	private int dropStrength = 160;

	public void OnGet(GameObject pickupPlace){
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		this.GetComponent<Collider>().enabled = false;
		this.transform.position = pickupPlace.transform.position;
		this.transform.rotation = pickupPlace.transform.rotation;
		this.transform.parent = pickupPlace.transform;
	}
	public void OnDrop(GameObject pickupPlace){
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		this.GetComponent<Collider>().enabled = true;
		this.transform.parent = null;
		this.transform.GetComponent<Rigidbody>().AddForce(pickupPlace.transform.forward * dropStrength);
		this.transform.GetComponent<Rigidbody>().AddForce(pickupPlace.transform.up * dropStrength/2);
	}
}
