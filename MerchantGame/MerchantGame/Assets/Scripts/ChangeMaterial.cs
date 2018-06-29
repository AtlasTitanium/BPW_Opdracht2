using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {
	void OnTriggerStay(Collider other){
		Material material = other.GetComponent<Material>();
		if(material != null){
			material.HeatMaterial();
		}
	}

}