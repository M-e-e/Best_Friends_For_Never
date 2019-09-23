using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public StringVariable timer;

	[SerializeField] private FloatVariable secondsCount;
	[SerializeField] private IntVariable minuteCount;
	[SerializeField] private IntVariable hourCount;

	private void Start()
	{
		ResetTimer();
	}

	void Update(){
		UpdateTimerUI();
	}
	//call this on update
	public void UpdateTimerUI(){
		//set timer UI
		secondsCount.Value += Time.deltaTime;
		if (hourCount.Value>0)
		{
			timer.Value = hourCount.Value +" : "+ minuteCount.Value +" : "+(int)secondsCount.Value;
		}
		else
		{
			timer.Value = minuteCount.Value +" : "+(int)secondsCount.Value ;
		}
		if(secondsCount.Value >= 60){
			minuteCount.Value++;
			secondsCount.Value = 0;
		}else if(minuteCount.Value >= 60){
			hourCount.Value++;
			minuteCount.Value = 0;
		}
	}

	public void ResetTimer()
	{
		secondsCount.Value = 0;
		minuteCount.Value = 0;
		hourCount.Value = 0;
	}
}
