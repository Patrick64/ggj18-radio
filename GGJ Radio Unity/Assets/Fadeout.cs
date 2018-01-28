using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeout : MonoBehaviour {
	public ScreenProgresser progressor;
	public void EndOfVideo()
	{
		progressor.TriggerTransition();
	}
}
