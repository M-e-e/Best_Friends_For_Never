using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using DG.Tweening;
using UnityAtoms.Extensions;

public class Disappearing_Platform : MonoBehaviour
{
	private bool invisible = false;

	[SerializeField] private float durationFadeOut = 1;
	[SerializeField] private float durationFadeIn = 1;
	[SerializeField] private float activationdelay = 1;
	[SerializeField] private float fadeInDelay=1;
	[SerializeField] private StringConstant player;

	[SerializeField] private float delay = 0;

	public enum State
	{
		Loop,
		Static,
		SleepLoop
	};

	public State currentState = State.Static;


	private void Start()
	{
		transform.GetChild(0).DOShakePosition(.1f, .01f, 10, 80).SetLoops(-1);

		if(currentState != State.Loop) return;
		StartCoroutine(FadeCoroutineLoop());


	}

/**	private void OnCollisionEnter2D(Collision2D other)
	{
		if (!invisible)
		{
			invisible = true;
			StartCoroutine(FadeCoroutine());
		}
	} **/

	private void OnCollisionStay2D(Collision2D other)
	{
		Debug.Log("test1");
		//if (!other.transform.gameObject.HasTag(player)) return;

		if (currentState == State.SleepLoop)
		{			Debug.Log("triggert");
			currentState=State.Loop;
			StartCoroutine(FadeCoroutine());
			return;
		}
		if (currentState != State.Static) return;
		if (other.transform.localPosition.y > +0.45f)
		{
			Debug.Log("test");


			if (!invisible)
			{
				invisible = true;
				StartCoroutine(FadeCoroutine());
			}
		}
	}

	IEnumerator FadeCoroutine()
	{

		transform.GetChild(0).GetComponent<SpriteRenderer>().DOFade(0, durationFadeOut).SetEase(Ease.InExpo);

		yield return new WaitForSeconds(durationFadeOut);

		GetComponent<BoxCollider2D>().enabled = false;

		yield return new WaitForSeconds(fadeInDelay);

		transform.GetChild(0).GetComponent<SpriteRenderer>().DOFade(1, durationFadeIn).SetEase(Ease.InQuad);


		GetComponent<BoxCollider2D>().enabled = true;


		yield return new WaitForSeconds(activationdelay);

		invisible = false;

		if (currentState == State.Loop) StartCoroutine(FadeCoroutine());
	}

	IEnumerator FadeCoroutineLoop()
	{
		yield return new WaitForSeconds(delay);
		StartCoroutine(FadeCoroutine());
	}
}
