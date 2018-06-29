using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour {
	//public GameObject sword, ring, shield, knife, crown;
	private Collider tableCollider;
	private GameObject smallIron, bigIron, smallCopper, bigCopper, smallGold, bigGold, smallWood, bigWood;
	public HashSet <ResourceType> ingredients = new HashSet <ResourceType>();
	public List <GameObject> allObjects = new List <GameObject>();
	public Recipe[] allRecipes;
	private Material mat;

	void Start(){
		tableCollider = GetComponent<Collider>();
	}
	void OnTriggerEnter(Collider other){
		mat = other.GetComponent<Material>();
		if(mat != null){
			if(mat.ChangeHeat <= mat.Heat){
				ingredients.Add(mat.type);
				allObjects.Add(other.gameObject);
			}
		}
		
	}

	void OnTriggerExit(Collider other){
		mat = other.GetComponent<Material>();
		if(mat != null){
			ingredients.Remove(mat.type);
			allObjects.Remove(other.gameObject);
		}
	}

	public void CraftItem(){
		foreach(Recipe recipe in allRecipes){
			if(ingredients.IsSupersetOf(recipe.ingredients)){
				Instantiate(recipe.result,new Vector3(transform.position.x, transform.position.y + 2, transform.position.z),transform.rotation);
				break;
			}
		}
		for(int i = allObjects.Count-1; i >= 0; i--){
			Destroy(allObjects[i]);
			allObjects.RemoveAt(i);
		}
		ingredients.Clear();
	}

}

[System.Serializable]
public class Recipe{
	public ResourceType[] ingredients;
	public GameObject result;
}