using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookAtPlayer : MonoBehaviour {

	void Update(){
		transform.LookAt(Camera.main.transform);
	}
}
