using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSound : MonoBehaviour
{
	public void OpenGate()
	{
		FindObjectOfType<AudioManager>().Play("OpenDoor");
	}

	public void CloseGate()
	{
		FindObjectOfType<AudioManager>().Play("CloseDoor");
	}

}
