using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class ParticleSystem_Player : MonoBehaviour
{
	[SerializeField] private FloatConstant DustEffectAfterHeight;

	[SerializeField] private LayerMask _layerMask;

	private ParticleSystem _particleSystem;

	private float TimeInAir = 0;
	private float TimeStamp;

	private void Start()
	{
		_particleSystem = GetComponent<ParticleSystem>();

		TimeStamp = Time.time;

	}

	private void Update()
	{
		if (Physics2D.Raycast(transform.position, Vector2.down, 1, _layerMask))
		{
			if (TimeInAir > DustEffectAfterHeight.Value)
			{
				_particleSystem.emission.SetBurst(0, new ParticleSystem.Burst(.01f, TimeInAir * 8));
				TimeInAir = 0;
				_particleSystem.Play();
			}

			TimeInAir = 0;
			TimeStamp = Time.time;
		}
		else
		{
			TimeInAir += Time.deltaTime;
		}
	}
}
