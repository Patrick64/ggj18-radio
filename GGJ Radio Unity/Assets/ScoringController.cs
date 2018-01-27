using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoringController : MonoBehaviour
{
	public Animator[] ScoringLights;
	public Animator faderAnimator;

	private int currentScoreIndex = 0;

	public void ScoreTriggered()
	{
		if(currentScoreIndex < ScoringLights.Length)
		{
			ScoringLights[currentScoreIndex].SetTrigger("Scored");
			currentScoreIndex++;

			if(currentScoreIndex >= ScoringLights.Length)
			{
				faderAnimator.SetTrigger("FadeOutScreen");
			}
		}
		else
		{
			Debug.Log("Maths broke");
		}
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(0);
		}
	}
}
