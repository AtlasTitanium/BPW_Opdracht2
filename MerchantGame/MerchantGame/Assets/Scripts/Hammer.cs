using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour, IInteractable, IGetable {
	public int dropStrength = 150;
	public AudioSource HammerAudio;
	public Animator HammerAnim;
	void Update(){
		if(HammerAnim.GetCurrentAnimatorStateInfo(0).length < HammerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime){
			HammerAnim.SetBool("Hitting", false);
		}
	}
	public void OnGet(GameObject pickupPlace){
		HammerAnim.enabled = true;
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		this.transform.position = pickupPlace.transform.position;
		this.transform.rotation = pickupPlace.transform.rotation;
		this.transform.parent = pickupPlace.transform;
	}
	public void OnDrop(GameObject pickupPlace){
		HammerAnim.enabled = false;
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		this.transform.parent = null;
		this.transform.GetComponent<Rigidbody>().AddForce(pickupPlace.transform.forward * dropStrength);
	}
	public void OnInteract(GameObject objectInFront){
		if(objectInFront.transform.GetComponent<Crafter>() != null){
			if(!HammerAnim.GetBool("Hitting")){
				Debug.Log("Hammer Hit");
				HammerAudio.Play();
				objectInFront.transform.GetComponent<Crafter>().CraftItem();
				HammerAnim.SetBool("Hitting", true);	
			}
		}
	}

	public void OnInteract(){
		Debug.Log("Maybe do damage to something?");
	}
}
