using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {

	private Animator animator;

	public GameObject tool;
	private GameObject toolClone;

	public GameObject decal;
	private GameObject decalClone;
	public Vector3 toolPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (tool)
		{
			CalcToolPos();

            if (Input.GetMouseButtonDown(0)) {
				UseTool (toolPos);
			}
		}

	}

	public void CreateTool() {
		toolClone = Instantiate(tool);
		animator = toolClone.GetComponent<Animator>();
		CalcToolPos();
	}

	void CalcToolPos() {
		toolPos = Input.mousePosition;
		toolPos.z = 45;
		toolPos = Camera.main.ScreenToWorldPoint(toolPos);
		toolClone.transform.position = toolPos;
	}

	public void DestroyTool() {
		Destroy(toolClone);
	}

	void UseTool (Vector3 position)
	{
		animator.SetTrigger ("hit");
		MakeDecal(position);

	}

	void MakeDecal(Vector3 position) {
		GameObject decalClone = Instantiate(decal);
		decalClone.transform.position = position;
		Destroy(decalClone, 60f);
	}
}
