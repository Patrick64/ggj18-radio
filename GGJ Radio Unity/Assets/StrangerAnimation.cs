using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerAnimation : MonoBehaviour
{
	private Animator titleAnimator;
	bool ending = false;
	private Vector3 mousePos;
	// Use this for initialization
	void Start () {
		titleAnimator = GetComponent<Animator>();
		mousePos = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetAxis("Submit") > 0)
		{
			ending = true;
		}

		if(!ending)
		{
			if(ButtonPressed())
			{
				titleAnimator.SetBool("Animate", true);
			}
			else
			{
				titleAnimator.SetBool("Animate", false);
			}

			if(Input.mousePosition != mousePos)
			{
				titleAnimator.SetBool("Animate", true);
				mousePos = Input.mousePosition;
			}
		}
		else
		{
			titleAnimator.SetBool("Animate", true);
		}
	}

	private bool ButtonPressed()
	{
		if(Input.GetAxis("HorizontalKey") != 0)
		{
			return true;
		}

		if(Input.GetAxis("VerticalKey") != 0)
		{
			return true;
		}

		if(Input.GetAxis("Horizontal") != 0)
		{
			return true;
		}

		if(Input.GetAxis("Vertical") != 0)
		{
			return true;
		}

		if(Input.GetAxis("PadHorizontal") != 0)
		{
			return true;
		}

		if(Input.GetAxis("PadVertical") != 0)
		{
			return true;
		}

		return false;
	}
}
