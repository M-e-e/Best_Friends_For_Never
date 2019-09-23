using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour
{
	private bool isOpen = true;

	public void DoSomething()
	{
		isOpen = !isOpen;
		Debug.Log("Gate is open:" + isOpen);
	}
}
