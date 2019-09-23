using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ActionsToSave : MonoBehaviour
{
	[SerializeField] private SavedActions transfer;


	public void TransferAction(SavedActions.actions action)
	{
		transfer.AddEvent(action);
	}
	/*public void UnTransferAction(SavedActions.actions action)
	{
		transfer.RemoveEvent(action);
	}*/
	public void ForceTransferAction(SavedActions.actions action)
	{
		transfer.ForceAddEvent(action);
	}


}
