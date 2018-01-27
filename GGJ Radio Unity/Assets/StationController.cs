using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
	public RadioStation[] RadioStations;
	public AudioSource RadioStatic;
	private ScoringController scoreController;

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
		bool solutionFound = false;
		for(int i = 0; i < RadioStations.Length; i++)
		{
			if(RadioStations[i].isBroadcasting && RadioStations[i].solution == solution)
			{
				solutionFound = true;
				RadioStations[i].DeactivateAudio();
				scoreController.ScoreTriggered();
				break;
			}
		}
		
		if(!solutionFound)
		{
			//Debug.Log("Solution Incorrect");
		}
	}

	private void UpdateActiveStations()
	{
		//ToDo
	}
}
