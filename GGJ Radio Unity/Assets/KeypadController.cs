using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
	public static Action<string> KeycodeEntered;

	public enum DigitalInput { Up, Down, Left, Right, Select };
	public KeypadButton[] KeypadArray;
	public Text DisplayText;

	private int selectedKey
	{
		get { return selectedKeyStorage; }
		set
		{
			selectedKeyStorage = value;
			UpdateKeyState();
		}
	}
	private int selectedKeyStorage = 0;

	private string currentCode = "";

	private bool upPressed = false, downPressed = false, leftPressed = false, rightPressed = false, selectPressed = false;

	private void Start()
	{
		KeypadArray[selectedKey].animator.SetBool("Selected", true);
		for(int i = 0; i < KeypadArray.Length; i++)
		{
			KeypadArray[i].keyIndex = i;
		}
	}

	private void Update()
	{
		if(Input.GetAxis("PadHorizontal") > 0)
		{
			if(!rightPressed)
			{
				rightPressed = true;
				RightPressed();
			}
		}
		else
		{
			rightPressed = false;
		}

		if(Input.GetAxis("PadHorizontal") < 0)
		{
			if(!leftPressed)
			{
				leftPressed = true;
				LeftPressed();
			}
		}
		else
		{
			leftPressed = false;
		}

		if(Input.GetAxis("PadVertical") > 0)
		{
			if(!upPressed)
			{
				upPressed = true;
				UpPressed();
			}
		}
		else
		{
			upPressed = false;
		}

		if(Input.GetAxis("PadVertical") < 0)
		{
			if(!downPressed)
			{
				downPressed = true;
				DownPressed();
			}
		}
		else
		{
			downPressed = false;
		}

		if(Input.GetAxis("Submit") > 0)
		{
			if(!selectPressed)
			{
				selectPressed = true;
				SelectPressed();
			}
		}
		else
		{
			selectPressed = false;
		}

		//Testing inputs
		/*if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			DigitalInputPressed(DigitalInput.Up);
		}

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			DigitalInputPressed(DigitalInput.Down);
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			DigitalInputPressed(DigitalInput.Left);
		}

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			DigitalInputPressed(DigitalInput.Right);
		}*/
	}

	public void DigitalInputPressed(DigitalInput buttonIn)
	{
		switch(buttonIn)
		{
			case DigitalInput.Up:
				UpPressed();
				break;
			case DigitalInput.Down:
				DownPressed();
				break;
			case DigitalInput.Left:
				LeftPressed();
				break;
			case DigitalInput.Right:
				RightPressed();
				break;
			case DigitalInput.Select:
				SelectPressed();
				break;
		}
	}

	private void UpPressed()
	{
		if(selectedKey - 3 >= 0)
		{
			selectedKey -= 3;
		}
	}

	private void DownPressed()
	{
		if(selectedKey + 3 < KeypadArray.Length)
		{
			selectedKey += 3;
		}
	}

	private void LeftPressed()
	{
		int col = selectedKey % 3;
		if(col > 0)
		{
			selectedKey--;
		}
	}

	private void RightPressed()
	{
		int col = selectedKey % 3;
		if(col < 2)
		{
			selectedKey++;
		}
	}

	private void SelectPressed()
	{
		switch(selectedKey)
		{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
				UpdateText((selectedKey + 1).ToString());
				break;
			case 9:
				if(currentCode.Length == 4)
				{
					if(KeycodeEntered != null)
					{
						KeycodeEntered.Invoke(currentCode);
					}
					ClearText();
				}
				break;
			case 10:
				UpdateText("0");
				break;
			case 11:
				ClearText();
				break;
		}
	}

	private void UpdateText(string newCharacter)
	{
		if(currentCode.Length < 4)
		{
			currentCode += newCharacter;
		}
		string toShow = currentCode;

		if(currentCode.Length < 4)
		{
			for(int i = 0; i < 4 - currentCode.Length; i++)
			{
				toShow += "?";
			}
		}

		DisplayText.text = toShow;
	}

	private void ClearText()
	{
		DisplayText.text = "????";
		currentCode = "";
	}

	private void UpdateKeyState()
	{
		for(int i = 0; i < KeypadArray.Length; i++)
		{
			if(i == selectedKey)
			{
				KeypadArray[i].animator.SetBool("Selected", true);
			}
			else
			{
				KeypadArray[i].animator.SetBool("Selected", false);
			}
		}
	}

	public void KeyClicked(int keyIndex)
	{
		selectedKey = keyIndex;
		SelectPressed();
	}
}
