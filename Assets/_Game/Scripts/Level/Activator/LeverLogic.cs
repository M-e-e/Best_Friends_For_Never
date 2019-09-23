using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Events;

public class LeverLogic : MonoBehaviour
{
	[SerializeField] private UnityEvent _eventPulled;
	[SerializeField] private UnityEvent _eventUnPulled;
	[SerializeField] private PickedUpItems pulledLevers;

	private SavePoint checkpoint;
	[SerializeField] private StringConstant checkpointTag;


	[SerializeField] private bool IsTimed = false;

	[SerializeField] private float AfterTime = 0;

	private bool pulled = false;
	private void Start()
	{
		checkpoint = AtomicTags.FindByTag(checkpointTag.Value).GetComponent<SavePoint>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (pulled)
		{
			//GetComponent<ActionsToSave>()?.UnTransferAction(Pull);//replace by take this from list
			pulledLevers.levers[0].Remove(gameObject);
			Debug.Log("remove "+gameObject);
			Debug.Log(pulledLevers.levers[0].Count);
			UnPull();
		}
		else
		{
			GetComponent<ActionsToSave>()?.ForceTransferAction(UnPullAllLevers);
			pulledLevers.levers[0].Add(gameObject);
			Debug.Log("add "+gameObject );
			Debug.Log(pulledLevers.levers[0].Count);
			Pull();

			if (IsTimed)
			{
				FindObjectOfType<AudioManager>().Play("TimerTicks");
				StartCoroutine(ResetPull());
			}
		}
	}

	public void Pull()
	{
		pulled = true;
		_eventPulled?.Invoke();

		FindObjectOfType<AudioManager>().Play("Lever");
	}

	public void UnPullAllLevers()
	{
		Debug.Log("pulling the levers. "+ pulledLevers.levers[0].Count+" are activated");

			foreach (GameObject obj in pulledLevers.levers[0])
			{
				Debug.Log("pulling "+obj);
				obj.GetComponent<LeverLogic>().UnPull();
			}
	}

	public void UnPull()
	{
		
		
		pulled = false;
		_eventUnPulled?.Invoke();
		FindObjectOfType<AudioManager>().Play("Lever");
	}

	IEnumerator ResetPull()
	{
		yield return new WaitForSeconds(AfterTime);

		FindObjectOfType<AudioManager>().StopPlaying("TimerTicks");

		pulledLevers.levers[checkpoint.numActive+1].Remove(gameObject);
		//GetComponent<ActionsToSave>()?.UnTransferAction(Pull);
		UnPull();
	}
}
