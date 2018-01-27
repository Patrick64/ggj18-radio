using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioStation : MonoBehaviour
{
	public AudioSource radioSource;
	public float audioPosition;
	public float tuningGap;
	public Slider TestSlider;
	public string solution;
	public bool isBroadcasting;

	void Start ()
	{
		radioSource = GetComponent<AudioSource>();
	}

	public void ActivateAudio()
	{
		isBroadcasting = true;
		radioSource.Play();
	}

	public void DeactivateAudio()
	{
		isBroadcasting = false;
		radioSource.Stop();
	}

	void Update()
	{
		float tuningDistance = Mathf.Abs(TestSlider.value - audioPosition);
		if(tuningDistance < tuningGap)
		{
			float newVolume = (tuningGap - tuningDistance) / tuningGap;
			radioSource.volume = newVolume;
		}
		else
		{
			radioSource.volume = 0;
		}
	}
}
