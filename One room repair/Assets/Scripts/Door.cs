using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public bool doorClosed = true;
	private GameController gameController;
	private ObjectController objectController;

	private AudioSource audioSource;
	public AudioClip doorOpen;
	public AudioClip doorClose;

	// Use this for initialization
	void Start () {
		objectController = GetComponent<ObjectController> ();
		gameController = FindObjectOfType<GameController> ();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (gameController.selectedTool == 0)
		{
			SwitchDoor ();
		}
	}

	public void SwitchDoor (){
		if (doorClosed) {
			doorClosed = false;
			objectController.SetSpriteState (2);
			audioSource.clip = doorOpen;
			audioSource.Play();
		} else {
			doorClosed = true;
			objectController.SetSpriteState (1);
			audioSource.clip = doorClose;
			audioSource.Play();
		}
	}
}
