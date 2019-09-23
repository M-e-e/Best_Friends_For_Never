using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
	[SerializeField] private VoidEvent DeathEvent;

	private void Start()
	{
		DeathEvent.Raise();
	}
}
