using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;


public class GoodVibrations :MonoBehaviour
{
	public void SetVibration(float seconds, float intensity=0.1f)
	{
		GamePad.SetVibration(PlayerIndex.One, intensity, intensity);
		GamePad.SetVibration(PlayerIndex.Two, intensity, intensity);

		StartCoroutine(StopVibratingAfterSeconds(seconds));
	}

	public void Vibrate()
	{
		SetVibration(0.15f);
	}

	IEnumerator StopVibratingAfterSeconds(float time)
	{
		yield return new WaitForSeconds(time);

		GamePad.SetVibration(PlayerIndex.One, 0, 0);
		GamePad.SetVibration(PlayerIndex.Two, 0, 0);
	}

}
