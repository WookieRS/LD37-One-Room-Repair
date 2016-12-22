using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour {

	GameController gameController;
	private ObjectController objectController;

	private AudioSource audioSource;
	public AudioClip switcher;

	// Use this for initialization
	void Start () {
		objectController = GetComponent<ObjectController> ();
		gameController = FindObjectOfType<GameController> ();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Switch(){
		transform.eulerAngles += new Vector3 (0, 0, 180);
		audioSource.clip = switcher;
		audioSource.Play();
	}

	void OnMouseDown(){
		if (gameController.selectedTool == 0)
		{
			gameController.SwitchLight ();
			Switch ();
		}

	}
}
