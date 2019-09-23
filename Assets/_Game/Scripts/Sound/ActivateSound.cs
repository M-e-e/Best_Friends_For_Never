using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSound : MonoBehaviour
{
	[SerializeField] private string SoundName;

	public void PlaySound()
	{
		FindObjectOfType<AudioManager>().Play(SoundName);
	}
}
