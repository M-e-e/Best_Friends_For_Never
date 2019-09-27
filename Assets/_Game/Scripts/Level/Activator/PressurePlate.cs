using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
	[SerializeField] private UnityEvent Pressure;
	[SerializeField] private UnityEvent NoPressure;

	private bool pressured = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!pressured)
		{
			Pressure.Invoke();
			pressured = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (pressured)
		{
			NoPressure.Invoke();
			pressured = false;
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{

		if (!pressured)
		{
			Pressure.Invoke();
			pressured = true;
		}
	}
}
