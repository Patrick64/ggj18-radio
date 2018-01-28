using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationController : MonoBehaviour
{
	public RadioStation[] RadioStations;
	public AudioSource RadioStatic;
	private ScoringController scoreController;
    public Text keypadText;

    private void Awake()
	{
		scoreController = GetComponent<ScoringController>();
	}

	private void OnEnable()
	{
		KeypadController.KeycodeEntered += SolutionSent;
	}

	private void OnDisable()
	{
		KeypadController.KeycodeEntered -= SolutionSent;
	}

	private void Update()
	{
		float highestVolume = 0f;
		foreach(RadioStation item in RadioStations)
		{
			if(item.radioSource.volume > highestVolume)
			{
				highestVolume = item.radioSource.volume;
			}
		}
		RadioStatic.volume = 1f - highestVolume;
	}

	private void SolutionSent(string solution)
	{
        string[] success = new string[] { "BRILL", "BOSS", "COOL", "RAD", "MONDO", "MEGA", "LEGIT", "PRIMO", "SICK" };
        string[] fail = new string[] { "BUNK", "DAG", "LAME", "BOGUS" };


        bool solutionFound = false;
		for(int i = 0; i < RadioStations.Length; i++)
		{
			if(RadioStations[i].isBroadcasting && RadioStations[i].solution == solution)
			{
                keypadText.text = success[Random.Range(0, success.Length)];
                StartCoroutine(setKeyPadText(1, "????"));
                solutionFound = true;
				RadioStations[i].DeactivateAudio();
                foreach (RadioStation station in RadioStations[i].stationsToTurnOnWhenComplete)
                {
                    station.ActivateAudio();
                }
				scoreController.ScoreTriggered();
                

            }
        }
		
		if(!solutionFound)
		{
            //Debug.Log("Solution Incorrect");
            keypadText.text = fail[Random.Range(0, fail.Length)];
            StartCoroutine(setKeyPadText(1, "????"));

        }
    }


    IEnumerator setKeyPadText(float seconds, string text)
    {

        yield return new WaitForSeconds(seconds);
        keypadText.text = text;
    }


    private void UpdateActiveStations()
	{
		//ToDo
	}
}
