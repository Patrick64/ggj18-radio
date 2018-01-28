using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
	public Animator faderAnimator;
	// Use this for initialization
	void Start () {
		
	}

    public void OnClick() {
		faderAnimator.SetTrigger("FadeOutScreen");
	}

	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Submit") > 0)
		{
			faderAnimator.SetTrigger("FadeOutScreen");
		}
	}
}
