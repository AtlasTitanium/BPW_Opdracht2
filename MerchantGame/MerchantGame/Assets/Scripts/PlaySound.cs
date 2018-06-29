using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public AudioSource playerAudio;
	public AudioClip audio;
	private bool stopPlaying = false;
	private bool startPlaying = false;
	void Update(){
		if(stopPlaying){
			Debug.Log("changeSong");
			playerAudio.volume -= 0.005f;
			if(playerAudio.volume <= 0.01f){
				playerAudio.Stop();
				playerAudio.clip = null;
				playerAudio.loop = true;
				playerAudio.Play();
				startPlaying = true;
				stopPlaying = false;
			}
		}
		if(startPlaying){
			playerAudio.Stop();
            playerAudio.clip = audio;
			playerAudio.volume = 0.1f;
            playerAudio.loop = true;
            playerAudio.Play();
			startPlaying = false;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(playerAudio.clip != audio){
				stopPlaying = true;
			}
		}
	}
}
