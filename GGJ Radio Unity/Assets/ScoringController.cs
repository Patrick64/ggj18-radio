using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoringController : MonoBehaviour
{
	public Animator[] ScoringLights;
	public Animator faderAnimator;
	public Animator trapAnimator;
    
	private int currentScoreIndex = 0;

	private void Awake()
	{
		faderAnimator.gameObject.SetActive(true);
	}

	public void ScoreTriggered()
	{
		if(currentScoreIndex < ScoringLights.Length)
		{
            

			ScoringLights[currentScoreIndex].SetTrigger("Scored");
			currentScoreIndex++;

			if(currentScoreIndex >= ScoringLights.Length)
			{
				StartCoroutine(WaitThenFade());
			}
        }
		else
		{
			Debug.Log("Maths broke");
		}
	}

	private IEnumerator WaitThenFade()
	{
		trapAnimator.SetTrigger("TriggerEnd");
		yield return new WaitForSeconds(2);
		faderAnimator.SetTrigger("FadeOutScreen");
	}

    private void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(0);
		}
	}
}
