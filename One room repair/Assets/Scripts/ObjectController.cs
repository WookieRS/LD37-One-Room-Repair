using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

	private GameController gameController;

	public Sprite[] spriteArray;
	public int textureState;
	public bool objectEnabled;

	private SpriteRenderer spriteRenderer;

	public AudioClip hitSound;
	private AudioSource audioSource;
    [Range(0,1f)]
    public float noise;

	public GameObject currentTool;
	public GameObject particleHammer;


	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		audioSource = GetComponent<AudioSource>();


		if (spriteArray.Length>0)
		{
			SetSpriteState (1);
		}

	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown(KeyCode.Alpha0)) {
//			SetSpriteState(0);
//		}
//
//		if (Input.GetKeyDown(KeyCode.S)) {
//			SwitchObject ();
//		}

			
	}

	public void SetSpriteState(int state){
		spriteRenderer.sprite = spriteArray [state];
	}

	void SwitchObject(){
		if (objectEnabled) {
			SetSpriteState (1);
			Debug.Log ("enabled");
		} else {
			SetSpriteState (0);
			Debug.Log ("disabled");
		}
	}

	void OnMouseDown(){
		//Play hit sound if activated hammer
		if (gameController.selectedTool == 1)
		{
			audioSource.clip = hitSound;
			audioSource.Play();
            gameController.UpdateProgressBar(noise);
			MakeParticles();

			//TODO Поправить костыль
			if (gameObject.name == "lamp_old" && gameController.lightEnabled)
			{
				gameController.SwitchLight();
			}
		}
	}

	void MakeParticles(){
		GameObject particlesClone = Instantiate(particleHammer);
		particlesClone.transform.position = currentTool.GetComponent<Tool>().toolPos;
		Destroy(particlesClone, 2);
	}


}
