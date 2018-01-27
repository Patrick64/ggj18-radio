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
    private AudioEchoFilter echoFilter;
    private AudioDistortionFilter distortionFilter;
    public RadioStation[] stationsToTurnOnWhenComplete; 

	void Start ()
	{
		radioSource = GetComponent<AudioSource>();
        echoFilter = GetComponent<AudioEchoFilter>();
        distortionFilter = GetComponent<AudioDistortionFilter>();
        distortionFilter.enabled = false;
        echoFilter.enabled = false;

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
            
            
            
            float currentArialPosition = 1-((90 + arial.arialSpriteAngle) / 180);
            
            float distortionLevel = Mathf.Abs(arialPosition - currentArialPosition) < arialGap * 4 ? Mathf.Abs(arialPosition - currentArialPosition) / arialGap / 4 : 1;
            float speed = 5*distortionLevel;
            float varyNumber = 0.5f + (Time.time % (4 / speed) > (2 / speed) ? (2 / speed) - Time.time % (2 / speed) : Time.time % (4 / speed)) * speed;
            bool isArialInPosition = currentArialPosition > arialPosition - arialGap && currentArialPosition < arialPosition + arialGap;
            if (isArialInPosition)
            {
                radioSource.pitch = 1;
                echoFilter.enabled = false;
                distortionFilter.enabled = false;
                radioSource.volume = newVolume;
            } else
            {
                radioSource.pitch = varyNumber;
                // echoFilter.enabled = true;
                //echoFilter.wetMix = distortionLevel*0.8f;
                // distortionFilter.enabled = true;
                //distortionFilter.distortionLevel = distortionLevel;
                //radioSource.volume = 0.01f; // Mathf.Min(0.01f*newVolume,1-distortionLevel) ;
            }
                
            // radioSource.dopplerLevel = (Time.time % (4 / speed) > (2 / speed) ? (2 / speed) - Time.time % (2 / speed) : Time.time % (4 / speed)) * speed; 
        }
		else
		{
			radioSource.volume = 0;
		}
	}
}
