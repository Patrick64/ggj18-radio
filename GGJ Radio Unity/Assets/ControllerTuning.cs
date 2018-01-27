using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllerTuning : MonoBehaviour {
    public Vector2? lastPosition = null;
    public Slider slider;
    public Image dial;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Vector2 newPosition = new Vector2(xAxis, yAxis);
        if (xAxis != 0 && yAxis != 0)
        {
            if (this.lastPosition != null)
            {
                float gamePadAngle = Vector2.SignedAngle((Vector2)lastPosition, newPosition);
                float angle = gamePadAngle * 0.04f;
                if (angle > 0.7) angle = 0.7f;
                if (angle < -0.7) angle = -0.7f;
                float sliderChange = Time.deltaTime * angle;

                slider.value -= sliderChange;
                //float angleForDial = Vector2.SignedAngle(new Vector2(0,1), newPosition);
                // dial.transform.rotation = Quaternion.Euler(0, 0, angleForDial);
                dial.transform.rotation = Quaternion.Euler(0, 0, -slider.value * 360 * 5);
            }
            this.lastPosition = newPosition;
        } else
        {
            float keySliderChange = Input.GetAxis("HorizontalKey") * 0.1f;
            slider.value += keySliderChange * Time.deltaTime;
            dial.transform.rotation = Quaternion.Euler(0, 0, -slider.value * 360 * 5);

        }







        


    }
}
