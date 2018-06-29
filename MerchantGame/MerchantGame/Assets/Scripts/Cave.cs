using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cave : MonoBehaviour {

	public GameObject TextObject;
	public List<GameObject> mats = new List<GameObject>();
	private int height;
	public Transform spawnpoint;
	public bool killBoi = false;
	//public int forceStrenght;
	void OnTriggerStay(Collider other){
		if(other.tag == "Player"){
			TextObject.SetActive(true);
			if(Input.GetKeyDown("i")){
				height = 0;
				for(int i = 0; i < mats.Count; i++){
					GameObject material = Instantiate(mats[i],new Vector3(spawnpoint.position.x,spawnpoint.position.y + height,spawnpoint.position.z),spawnpoint.rotation);
					height += 2;
					//material.GetComponent<Rigidbody>().AddForce(transform.forward * forceStrenght);
					material = null;
				}
			}
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			TextObject.SetActive(false);
		}
	}
}
