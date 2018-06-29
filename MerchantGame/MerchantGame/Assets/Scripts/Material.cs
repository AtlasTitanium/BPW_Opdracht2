using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType{BigIron,SmallIron,BigCopper,SmallCopper,BigGold,SmallGold,BigWood,SmallWood}

public class Material : MonoBehaviour, IGetable{

	public ResourceType type;
	public float Heat = -15f;
	private float HeatOrigin;
	private float HeatSpeed = 0.05f;
	public int ChangeHeat;
	private int dropStrength = 160;
	private float r;
	void Start(){
		HeatOrigin = Heat;
		r = GetComponent<Renderer>().material.color.r;
	}
	void Update(){
		GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r + Heat/100*Time.deltaTime,GetComponent<Renderer>().material.color.g,GetComponent<Renderer>().material.color.b);
		if(GetComponent<Renderer>().material.color.r < r){
			GetComponent<Renderer>().material.color = new Color(r,GetComponent<Renderer>().material.color.g,GetComponent<Renderer>().material.color.b);
		}
		if(GetComponent<Renderer>().material.color.r > 2.0f){
			GetComponent<Renderer>().material.color = new Color(2.0f,GetComponent<Renderer>().material.color.g,GetComponent<Renderer>().material.color.b);
		}
		if(Heat > HeatOrigin){
			Heat -= HeatSpeed/2 * Time.deltaTime;
		}
		if(Heat >= 101){
			Heat = 100;
		}
		if(Heat < HeatOrigin){
			Heat = HeatOrigin;
		}
	}

	public void HeatMaterial(){
		if(type == ResourceType.BigWood || type == ResourceType.SmallWood){
			Destroy(this.gameObject);
		}
		Heat += HeatSpeed;
	}

	public void CoolMaterial(){
		Heat -= 50;
		GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r /8,GetComponent<Renderer>().material.color.g,GetComponent<Renderer>().material.color.b);
	}

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
