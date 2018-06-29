using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour {
	public LayerMask raycastIgnoreLayer;
	public LayerMask materialsLayer;
	public Camera playerCamera;
	public GameObject itemPlace;
	private GameObject heldItem;

	//private IInteractable currentInteractable;
	private bool holdingItem = false;
	private bool onlyOnce = true;
	public float putDownStrength;
	private GameObject thedoor;


	void Update () {
		if(Input.GetKeyDown("e")){
			if(heldItem != null){
				heldItem.transform.GetComponent<Rigidbody>().useGravity = true;
				heldItem.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				heldItem.transform.parent = null;
				heldItem.transform.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * putDownStrength);
				heldItem = null;
				holdingItem = false;
			}
		}

		if(heldItem != null){
			if(heldItem.tag == "Hammer"){
				RaycastHit hitt;
				if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitt, 3, materialsLayer)){
					Debug.Log("there's a material");
					if(Input.GetMouseButtonDown(0)){
						
						//heldItem.OnInteract(hitt.transform.gameObject);
					}
				}
			}
			if(Input.GetMouseButtonDown(0)){
				//if(currentInteractable != null){
				//	//currentInteractable.OnInteract();
				//}
			}


			if(onlyOnce){
				heldItem.transform.position = itemPlace.transform.position;
				heldItem.transform.rotation = itemPlace.transform.rotation;
				heldItem.transform.GetComponent<Rigidbody>().useGravity = false;
				heldItem.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
				heldItem.transform.parent = itemPlace.transform;
				onlyOnce = false;
			}
		} else {
			RaycastHit hit;
			if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 3, ~raycastIgnoreLayer)){
				Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				if(hit.transform.tag == "PickupObject" || hit.transform.tag == "Hammer"){
					Debug.Log("there's a pickup object");
					if(Input.GetMouseButtonDown(1)){
						if(holdingItem){
							heldItem.transform.position = hit.transform.position;
							heldItem.transform.rotation = hit.transform.rotation;
							heldItem.transform.GetComponent<Rigidbody>().useGravity = true;
							heldItem.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
							heldItem.transform.parent = null;
							heldItem = hit.transform.gameObject;

							//IInteractable interact = hit.collider.GetComponent<IInteractable>();
							//if(interact !=null){
								//currentInteractable = interact;
							//}

							onlyOnce = true;
						} else {
							heldItem = hit.transform.gameObject;
							onlyOnce = true;
							holdingItem = true;
						}
					}
				}
				if(hit.transform.tag == "Door"){
					Debug.Log("there's a door");
					if(Input.GetMouseButtonDown(1)){
						thedoor = hit.transform.gameObject;
						thedoor.transform.GetComponent<Animator>().SetBool("Open",!thedoor.transform.GetComponent<Animator>().GetBool("Open"));
						//StartCoroutine(OpenDoor());
					}
				}
			}
		}
	}

	IEnumerator OpenDoor(){
		yield return new WaitForSeconds(5);
		thedoor.transform.GetComponent<Animator>().SetBool("Open",false);
	}
}
