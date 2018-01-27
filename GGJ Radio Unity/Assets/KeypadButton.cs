using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
	public Animator animator;
	public int keyIndex;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void Clicked()
	{
		//This is a horrible and I have no shame
		transform.parent.parent.GetComponent<KeypadController>().KeyClicked(keyIndex);
	}
}
