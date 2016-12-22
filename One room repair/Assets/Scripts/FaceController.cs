using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceController : MonoBehaviour {

	private GameController gameController;
	public GrenadeLauncher launcher;

	private AudioSource audioSource;
	public AudioClip hitSound;

	private Animator animator;
	private Door door;

	public Text bubbleText;

	public string[] textArray;

	[Range(-1,1)]
	public float hitInFaceValue; 
	[Range(-1,1)]
	public float relaxValue;

	public ParticleSystem bloodParticles;
	public GameObject bloodPrint;


	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController>();
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		door = FindObjectOfType<Door>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ThrowGrend(){
		if (gameController.noiseLevel >0.5f)
		{
			launcher.ThrowGrenade();
			gameController.UpdateProgressBar(relaxValue);
			ResetTriggers();
		}

	}

	void OnMouseDown(){
		//Play hit sound if activated hammer
		if (gameController.selectedTool == 1)
		{
			audioSource.clip = hitSound;
			audioSource.Play();
			bloodParticles.Emit(Random.Range(10,50));
			GameObject bloodPrintClone = Instantiate(bloodPrint);

			Vector3 randomPos = new Vector3(Random.Range(0.2f,-2f), Random.Range(-1f, 2f));

			bloodPrintClone.transform.position = transform.position + randomPos;
			Destroy(bloodPrintClone, 60);


			gameController.UpdateProgressBar(hitInFaceValue);
			if (gameController.noiseLevel < 0.5f)
			{
				Hide();
			}
		}
	}

	public void LookIn(){
		RandomText();
		if (!door.doorClosed)
		{
			animator.SetTrigger("face_in");
		}
		else
		{
			door.SwitchDoor();
			animator.SetTrigger("face_in");
		}	
	}

	public void Hide(){
		animator.SetTrigger("face_out");
	}

	public void ResetTriggers(){
		animator.ResetTrigger("face_in");
		animator.ResetTrigger("face_out");
	}

	public void CloseDoor(){
		if (!door.doorClosed){
			door.SwitchDoor();
		}
	}

	void RandomText(){
		int randInt = Random.Range(0, textArray.Length);
		bubbleText.text = textArray[randInt];
	}
}
