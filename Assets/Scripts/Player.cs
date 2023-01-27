using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public Text scoreText;
	private int scoreCounter = 0;
	public Camera myCamera;
	private AudioSource a;
	public AudioClip collectSound;

	void Start(){
		a = myCamera.GetComponent<AudioSource> ();
	}

	void FixedUpdate(){
		if(this.transform.position.y < -5){
			SceneManager.LoadScene ("LOSE");
		}
	}

	void OnTriggerEnter(Collider x){
		if(x.gameObject.tag == "pick"){
			x.gameObject.SetActive (false);
			scoreCounter++;
			scoreText.text = "Score: " + scoreCounter;
			a.PlayOneShot (collectSound);
			if(scoreCounter == 6){
				SceneManager.LoadScene ("WIN");
			}
		}
	}
}
