using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class FinalPickup : MonoBehaviour
{
	[SerializeField] private VoidEvent nextLevelEvent;

	private bool triggered;
	//on 2d trigger enter: raise next level event
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (triggered) return;
		triggered = true;
		nextLevelEvent.Raise();

	}
}
