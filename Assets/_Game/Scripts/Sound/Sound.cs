using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
	public string name;

	public AudioClip clip;

	[Range(0,1)]
	public float volume;
	[Range(-3f, 3f)]
	public float pitch = 1;

	public bool loop = false;

	public bool randomized = false;

	[Range(0,1)]
	public float volumeMax;
	[Range(-3f, 3f)]
	public float pitchMax;

	[HideInInspector]
	public AudioSource source;

}
