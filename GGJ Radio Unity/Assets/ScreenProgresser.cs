using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenProgresser : MonoBehaviour {

	public int targetScreen;
	
	public void TriggerTransition()
	{
		SceneManager.LoadScene(targetScreen);
	}
}
