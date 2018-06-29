using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour {
	public LayerMask raycastIgnoreLayer;
	public Camera playerCamera;
	public GameObject itemPlace;
	public GameObject holdingItem;
	public int RayRange = 10;

	void Update () {
		//Check if there's a pickupable item in front
		RaycastHit hit;
		if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, RayRange, ~raycastIgnoreLayer)){
			IGetable pickup = hit.collider.GetComponent<IGetable>();
			if(holdingItem == null){
				if(pickup != null){
					Debug.Log("there's a pickup object");
					if(Input.GetKeyDown("e")){
						pickup.OnGet(itemPlace);
						holdingItem = hit.transform.gameObject;
						return;
					}
				}
			}
		}

		//when you're holding an item
		if(holdingItem != null){
			RaycastHit hot;
			if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hot, RayRange, ~raycastIgnoreLayer)){
				IClickable clicable = hot.collider.GetComponent<IClickable>();
				if(clicable != null){
					if(Input.GetMouseButtonDown(1)){
						if(holdingItem != null){
							clicable.OnClick(holdingItem, this.gameObject);
						}
						return;
					}
				}
			}
			//if held item is an interactable
			IInteractable interactable = holdingItem.GetComponent<IInteractable>();
			if(interactable != null){
				RaycastHit het;
				if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out het, RayRange, ~raycastIgnoreLayer)){
					Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
					Crafter CraftingTable = het.collider.GetComponent<Crafter>();
					if(Input.GetMouseButtonDown(0)){
						if(CraftingTable != null){
							interactable.OnInteract(CraftingTable.gameObject);
						} else {
							interactable.OnInteract();
						}
						return;
					}
				}
			}

			//drop the held item
			if(Input.GetKeyDown("e")){
				holdingItem.GetComponent<IGetable>().OnDrop(playerCamera.gameObject);
				holdingItem = null;
			}
		}

		//Check if there's an clickable object in front;
		RaycastHit hat;
		if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hat, RayRange, ~raycastIgnoreLayer)){
			IClickable clicable = hat.collider.GetComponent<IClickable>();
			if(clicable != null){
				if(Input.GetMouseButtonDown(1)){
					clicable.OnClick();
					return;
				}
			}
		}
	}
}
