using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioStation : MonoBehaviour
{
	public AudioSource radioSource;
	public float audioPosition;
	public float tuningGap;
    public float arialPosition;
    public float arialGap;
	public Slider TestSlider;
    public ArialTuning arial;
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
            float speed = 4;
            float varyNumber = 0.3f + (Time.time % (4 / speed) > (2 / speed) ? (2 / speed) - Time.time % (2 / speed) : Time.time % (4 / speed)) * speed;
            float currentArialPosition = 1-((90 + arial.arialSpriteAngle) / 180);
            bool isArialInPosition = currentArialPosition > arialPosition - arialGap && currentArialPosition < arialPosition + arialGap;
            if (isArialInPosition)
            {
                radioSource.pitch = 1;
            } else
            {
                radioSource.pitch = varyNumber;
            }
                
            // radioSource.dopplerLevel = (Time.time % (4 / speed) > (2 / speed) ? (2 / speed) - Time.time % (2 / speed) : Time.time % (4 / speed)) * speed; 
        }
		else
		{
			radioSource.volume = 0;
		}
	}
}
