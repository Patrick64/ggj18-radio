using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
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

	private void Start()
	{
		KeypadArray[selectedKey].animator.SetBool("Selected", true);
	}

	private void Update()
	{
		//Testing inputs
		if(Input.GetKeyDown(KeyCode.UpArrow))
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
		}

		if(Input.GetKeyDown(KeyCode.Return))
		{
			DigitalInputPressed(DigitalInput.Select);
		}
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
				Debug.Log(currentCode);
				ClearText();
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
}
