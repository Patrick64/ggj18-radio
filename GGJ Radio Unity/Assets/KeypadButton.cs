using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
	public Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}
}
