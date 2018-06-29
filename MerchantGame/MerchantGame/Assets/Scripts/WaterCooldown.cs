using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCooldown : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		Material material = other.GetComponent<Material>();
		if(material != null){
			material.CoolMaterial();
		}
	}	
}
