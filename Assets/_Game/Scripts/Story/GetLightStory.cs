using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetLightStory : MonoBehaviour
{
	public UnityEvent stuff;

	private void OnTriggerEnter2D(Collider2D other)
	{
		stuff.Invoke();

		FindObjectOfType<AudioManager>().Play("SpecialItem");

		Destroy(gameObject,.1f);


	}
}
