using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringController : MonoBehaviour
{
	public Animator[] ScoringLights;

	private int currentScoreIndex = 0;

	public void ScoreTriggered()
	{
		if(currentScoreIndex < ScoringLights.Length)
		{
			ScoringLights[currentScoreIndex].SetTrigger("Scored");
			currentScoreIndex++;
			if(currentScoreIndex >= ScoringLights.Length)
			{
				Debug.Log("A WINNER IS YOU!");
			}
		}
		else
		{
			Debug.Log("Maths broke");
		}
	}
}
