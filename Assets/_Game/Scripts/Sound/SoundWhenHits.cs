using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.Extensions;
using UnityEngine;

public class SoundWhenHits : MonoBehaviour
{
	[SerializeField] private StringConstant ColliderTag;

	[SerializeField] private string SoundName;

	[SerializeField] private string SoundName_WhenLeft;

	[SerializeField] private bool Trigger = false;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(SoundName == "") return;

		if (Trigger) return;

		if(!other.gameObject.HasTag(ColliderTag)) return;

		FindObjectOfType<AudioManager>().Play(SoundName);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(SoundName == "") return;

		if (!Trigger) return;

		if(!other.gameObject.HasTag(ColliderTag)) return;

		FindObjectOfType<AudioManager>().Play(SoundName);
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if(SoundName_WhenLeft == "") return;

		if (Trigger) return;

		if(!other.gameObject.HasTag(ColliderTag)) return;

		FindObjectOfType<AudioManager>().Play(SoundName_WhenLeft);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(SoundName_WhenLeft == "") return;

		if (!Trigger) return;

		if(!other.gameObject.HasTag(ColliderTag)) return;

		FindObjectOfType<AudioManager>().Play(SoundName_WhenLeft);
	}
}
