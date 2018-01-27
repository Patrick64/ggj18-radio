using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllerTuning : MonoBehaviour {
    public Vector2? lastPosition = null;
    public Slider slider;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Vector2 newPosition = new Vector2(xAxis, yAxis);
        if (this.lastPosition != null && xAxis != 0 && yAxis != 0)
        {
            float angle = Vector2.SignedAngle((Vector2)lastPosition, newPosition)*0.01f;
            if (angle > 0.7) angle = 0.7f;
            if (angle < -0.7) angle = -0.7f;
            float sliderChange = Time.deltaTime * angle;
            
            slider.value -= sliderChange;
        }
        
        this.lastPosition = newPosition;


        float keySliderChange = Input.GetAxis("HorizontalKey") * 0.1f;
        slider.value += keySliderChange * Time.deltaTime;

    }
}
