using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuningTester : MonoBehaviour
{
	public AudioSource TestAudio;
	public Slider TestSlider;
	public float audioPosition;
	public float tuningGap;
	
	void Update ()
	{
		float tuningDistance = Mathf.Abs(TestSlider.value - audioPosition);
		if(tuningDistance < tuningGap)
		{
			float newVolume = (tuningGap - tuningDistance) / tuningGap;
			TestAudio.volume = newVolume;
			Debug.Log(newVolume);
		}
		else
		{
			TestAudio.volume = 0;
		}
	}
}