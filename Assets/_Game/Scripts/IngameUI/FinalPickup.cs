using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class FinalPickup : MonoBehaviour
{
	[SerializeField] private VoidEvent nextLevelEvent;
	//on 2d trigger enter: raise next level event
	private void OnTriggerEnter2D(Collider2D other)
	{
		nextLevelEvent.Raise();
	}
}
