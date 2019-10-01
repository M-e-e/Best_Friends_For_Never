using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSound : MonoBehaviour
{
	private void OnDisable()
	{
		FindObjectOfType<AudioManager>().Play("OpenDoor");
	}

	private void OnEnable()
	{
		FindObjectOfType<AudioManager>().Play("CloseDoor");
	}
}
