using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour {

	public GameObject grenade;
	private GameObject grenadeClone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.O))
		{
			ThrowGrenade();
		}
	}

	public void ThrowGrenade(){
		float randomX = Random.Range(-50f, -200f);
		float randomY = Random.Range(30f, 300f);
		float randomZ = Random.Range(0f, 1f);

		Vector3 newDirection = new Vector3(randomX, randomY, 0);

		grenadeClone = Instantiate(grenade);
		grenadeClone.transform.position = transform.position;
		Rigidbody2D cloneRigidbody = grenadeClone.GetComponent<Rigidbody2D>();
		cloneRigidbody.AddForce(newDirection);
		cloneRigidbody.AddTorque(3f);

	}
}
