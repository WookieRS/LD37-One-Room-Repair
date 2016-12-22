using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public Light lamp;
	public SpriteRenderer lampFlare;
	public CanvasRenderer DarkLayer;

	//Свет
	public bool lightEnabled;
	private ObjectController lampController;

	//Курсор - объект
	public int selectedTool;
	public GameObject currentTool;
	public GameObject hammer;
	private Tool tool;
	public GameObject[] decalsArray;

    //Progress
	public float noiseLevel;
    [Range(0,1)]
    public float relaxPerSec; 
    public Image progressBar;

	//Face
	public FaceController face;

	//Credits animation
	public Animator creditsAnimator;

	// Use this for initialization
	void Start () {
		selectedTool = 0;
		lightEnabled = lamp.enabled;
		lampController = lamp.GetComponentInParent<ObjectController> ();
		DarkLayer.SetAlpha (0);
        UpdateProgressBar(0);
		face = FindObjectOfType<FaceController>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			CancelSelect ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SelectHammer();
		}

        if (noiseLevel > 0f)
        {
            noiseLevel -= relaxPerSec/1000;
            progressBar.fillAmount = noiseLevel;
        }

	}

	public void SwitchLight(){
		if (lightEnabled) {
			lamp.enabled = false;
			lightEnabled = false;
			lampFlare.enabled = false;
			DarkLayer.SetAlpha (1);
			lampController.SetSpriteState (2);
		} else {
			lamp.enabled = true;
			lightEnabled = true;
			lampFlare.enabled = true;
			DarkLayer.SetAlpha (0);
			lampController.SetSpriteState (1);
		}
	}

	public void SelectHammer(){
        if (selectedTool != 0)
        {
            CancelSelect();
        }
        selectedTool = 1;
		tool = FindObjectOfType<Tool>();
		tool.tool = hammer;
		tool.decal = decalsArray[1];

		tool.CreateTool();
	}

	void CancelSelect(){
		tool.DestroyTool();
		selectedTool = 0;
		tool.tool = null;
		tool.decal = null;
	}

    public void UpdateProgressBar(float noise){
        noiseLevel += noise;
        if (noiseLevel >1){
            noiseLevel = 1;
			face.LookIn();
        }
		if (noiseLevel <0)
		{
			noiseLevel = 0;
		}


        progressBar.fillAmount = noiseLevel;
    }

	public void ToggleCredits(){
		if (selectedTool == 0)
		{
			creditsAnimator.SetTrigger("show");
		}
	}
}

