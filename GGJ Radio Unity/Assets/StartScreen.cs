using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnClick() {
        SceneManager.LoadScene("testscene");
    }

	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Submit") > 0)
		{
			SceneManager.LoadScene("testscene");
		}
	}
}
