using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Best Enemies Forever/test/test")]
public class SavedActions : ScriptableObject
{
	//Array/List of Actions
	//public  Action[] events;

	public delegate void actions();

	private actions[] myActions;
	public actions eventActivateDestructables;
	[SerializeField] private StringConstant PlayerTag;
	[SerializeField] private StringConstant checkpointTag;
	private SavePoint checkpoint;

	//Function to add Actions to Array


	public void AddEvent(actions action)
	{
		checkpoint = AtomicTags.FindByTag(checkpointTag.Value).GetComponent<SavePoint>();
		if (myActions == null)
		{
			myActions = new actions[checkpoint.hasBeenActivated.Length+1];
		}

		/*for (int i=checkpoint.numActive+1;i<checkpoint.hasBeenActivated.Length;i++)
		{
			if (!checkpoint.hasBeenActivated[i])
			{
				events[i] -= action;
				events[i] += action;
				Debug.Log("Added " + action.GetMethodInfo() +" to checksave " +i);
			}
		}*/


		if (checkpoint.numActive>=myActions.Length)
		{
			Debug.Log("returning empty");
			return;
		}

		Debug.Log(action.GetMethodInfo());
		myActions[checkpoint.numActive + 1] -= action;
		myActions[checkpoint.numActive + 1] += action;

	}

	public void RemoveEvent(actions action)
	{
		myActions[checkpoint.numActive + 1] -= action;
	}

	public void ForceAddEvent(actions action)
	{
		eventActivateDestructables -= action;
		eventActivateDestructables += action;
		//Debug.Log("Added: " + action.GetMethodInfo());
	}

	public void InvokeEvent()
	{
		checkpoint = AtomicTags.FindByTag(checkpointTag.Value).GetComponent<SavePoint>();
		//Debug.Log(checkpoint.numActive+1 +" checkpoints are active");
		Debug.Log("a cockroach");
		if (checkpoint.numActive >= 0)
		{
			//Debug.Log("invoke action from set " + checkpoint.numActive );
			//Debug.Log(myActions?[checkpoint.numActive]?.GetMethodInfo());
			Debug.Log("in a bunker");
			myActions?[checkpoint.numActive]?.Invoke();
		}
	} //on death

	public void ResetCurrentCheckpoint()
	{
		//reset active checkpoint
		myActions[checkpoint.numActive]=null;
	}

	public void InvokeDestructables()
	{
		Debug.Log("invoking");
		eventActivateDestructables?.Invoke();
		Debug.Log(eventActivateDestructables?.GetMethodInfo());
	}

/*	public void ResetDestructables()
	{
		if (eventActivateDestructables==null)
		{
			return;
		}
		foreach (Action action in  eventActivateDestructables?.GetInvocationList() )
		{
			eventActivateDestructables -= action;
		}
	}*/

	public void LoadScene()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		//don´t reload scene but reset Player
		//set all relevant variables back to normal values
		foreach (GameObject obj in AtomicTags.FindAllByTag(PlayerTag.Value))
		{
			obj.GetComponent<Player_Movement>().ResetBuffs();
		}


		//then invoke event
		InvokeEvent();

	}


}
