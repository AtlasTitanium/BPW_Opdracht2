using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {
	public GameObject NPC;
	public GameObject opponent;
	public GameObject[] waypoints;
	public float rotSpeed = 2.0f;
	public float accuracy = 6.0f;

	
	void Awake(){
		waypoints = GameObject.FindGameObjectsWithTag("waypoint");
	}
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		NPC = animator.gameObject;
		opponent = NPC.GetComponent<AI>().GetPlayer();
	}

}