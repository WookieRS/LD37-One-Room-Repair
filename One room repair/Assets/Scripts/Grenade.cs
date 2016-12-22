using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	public GameObject explode;
	public GameObject decal;
	private GameObject explodeClone;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		Invoke("Explode", 5);
		gameController = FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Explode(){
		explodeClone = Instantiate(explode);
		explodeClone.transform.position = transform.position;
		MakeDecal();
		Destroy(gameObject);
		Destroy(explodeClone, 5);

	}

	public void MakeDecal(){
		if (transform.position.y<= -2.2f)
		{
			GameObject decalClone = Instantiate(decal);
			decalClone.transform.position = transform.position;
			Destroy(decalClone, 120);
		}
	}

	void OnMouseDown(){
		if (gameController.selectedTool == 1)
		{
			Explode();
		}
	}

}
