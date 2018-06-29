using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {
	public AudioSource JumpSound;
	public int force;
	private bool ifJump = true;
	void Update(){
		transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
		if(ifJump){
			JumpSound.Play();
			this.GetComponent<Rigidbody>().AddForce(transform.up * force/2);
			this.GetComponent<Rigidbody>().AddForce(transform.forward * force);
			StartCoroutine(WaitEndJump());
			ifJump = false;
		}
		
	}

	IEnumerator WaitEndJump(){
		yield return new WaitForSeconds(Random.RandomRange(1f,5f));
		ifJump = true;
	}
}
