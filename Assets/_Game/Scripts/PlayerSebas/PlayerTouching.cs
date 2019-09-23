using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityAtoms.Extensions;
using UnityEngine.Experimental.PlayerLoop;
using DG.Tweening;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerTouching : MonoBehaviour
{

	[SerializeField] private VoidEvent DeathEvent;

	[SerializeField] private StringConstant[] SavingTouch;

	[SerializeField] private BoolVariable IsTouching;

	//[SerializeField] private BoolVariable GameOver;
	private bool GameOver = false;

	[SerializeField] public FloatVariable TimeBeforeDeath;
	[SerializeField] public FloatVariable StartBlinkingIn;
	[SerializeField] private FloatVariable TimeSinceTouch;
	private float TimeStamp;

	private Sequence BlinkingSequencePlayer;
	private bool IsBlinking = false;

	private void Start()
	{
		IsTouching.Value = false;
		TimeStamp = Time.time;
	}

	public void OnLevelResetInsteadOfFuckingReloading()
	{
		StartCoroutine(OnLevelResetInsteadOfFuckingReloadingCoroutine());
	}

	IEnumerator OnLevelResetInsteadOfFuckingReloadingCoroutine()
	{
		yield return new WaitForSeconds(0.05f);

		//Debug.Log(gameObject.name);

		IsTouching.Value = false;

		TimeStamp = Time.time;

		GameOver = false;

		IsBlinking = false;

		BlinkingSequencePlayer?.Kill();

		GetComponentInChildren<SpriteRenderer>()
			.DOFade(1, .1f);
	}

	private void Update()
	{
		TimeSinceTouch.Value = (IsTouching.Value) ? 0 : Time.time - TimeStamp;

		//check GameOver
		if (TimeBeforeDeath.Value < TimeSinceTouch.Value && !GameOver)
		{
			Debug.Log("Death has been raised");
			GameOver = true;
			DeathEvent.Raise();
		}

		if (StartBlinkingIn.Value < TimeSinceTouch.Value && !IsBlinking)
		{
			IsBlinking = true;

			BlinkingSequencePlayer = DOTween.Sequence();
			BlinkingSequencePlayer.Append(GetComponentInChildren<SpriteRenderer>()
				.DOFade(.1f, TimeBeforeDeath.Value - StartBlinkingIn.Value).SetEase(Ease.InOutFlash, 15, -1));
		}
	}

	private void OnCollisionStay2D(Collision2D other)
    {
	    foreach (var st in SavingTouch)
	    {
		    if (other.gameObject.HasTag(st))
		    {
			    IsTouching.Value = true;
			    BlinkingSequencePlayer.Kill();
			    IsBlinking = false;

			    GetComponentInChildren<SpriteRenderer>()
				    .DOFade(1, .1f);

			    break;
		    }
	    }
    }

	private void OnCollisionExit2D(Collision2D other)
	{
		foreach (var st in SavingTouch)
		{
			if (other.gameObject.HasTag(st))
			{
				IsTouching.Value = false;
				TimeStamp = Time.time;

				break;
			}
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		foreach (var st in SavingTouch)
		{
			if (other.gameObject.HasTag(st))
			{
				IsTouching.Value = true;
				BlinkingSequencePlayer.Kill();
				IsBlinking = false;

				GetComponentInChildren<SpriteRenderer>()
					.DOFade(1, .1f);

				break;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		foreach (var st in SavingTouch)
		{
			if (other.gameObject.HasTag(st))
			{
				IsTouching.Value = false;
				TimeStamp = Time.time;

				break;
			}
		}
	}

}
