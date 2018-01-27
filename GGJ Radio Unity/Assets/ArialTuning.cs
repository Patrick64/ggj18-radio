using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArialTuning : MonoBehaviour {

    public Image arialSprite;
    private float xAxis;
    private float yAxis, angle;
    public float arialSpriteAngle = -45;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        xAxis = Input.GetAxis("RightStickHorizontal");
        yAxis = Input.GetAxis("RightStickVertical");
        
        Vector2 newPosition = new Vector2(xAxis, yAxis);
        angle = Vector2.SignedAngle(new Vector2(0, -1), newPosition);
        angle = -(angle);
        if ((System.Math.Abs(xAxis) > 0.5 || System.Math.Abs(yAxis) > 0.5))
        {
            if (angle < -90) angle = -90;
            if (angle > 90) angle = 90;
            arialSpriteAngle = angle;
            //arialSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        //arialSprite.transform.rotation.Set(0f, 0f, angle, 0f);
        //arialSprite.rectTransform.rotation.Set(0f, 0f, angle, 0f);


        float keyChange = Input.GetAxis("VerticalKey") ;
        arialSpriteAngle += keyChange * Time.deltaTime * 200;
        //float newAngle = arialSprite.transform.rotation.z + keyChange * Time.deltaTime * 100;

        if (arialSpriteAngle < -90) arialSpriteAngle = -90;
        if (arialSpriteAngle > 90) arialSpriteAngle = 90;

        arialSprite.transform.rotation = Quaternion.Euler(0, 0, arialSpriteAngle+90);

    }
}
