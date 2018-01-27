using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
	public RadioStation[] RadioStations;

	private void OnEnable()
	{
		KeypadController.KeycodeEntered += SolutionSent;
	}

	private void OnDisable()
	{
		KeypadController.KeycodeEntered -= SolutionSent;
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
				//ToDo: increment solution count
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
