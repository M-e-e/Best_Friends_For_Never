using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
	//listen to Jump Axis: raise jump event
	//listen to Horizontal1 Axis: raise float event horizontal1
	[SerializeField] private Sets chooseSet;
	[Tooltip("0:left stick x1, 1:left stick x2, 2:a1 down, 3:a2 down, 4:a1 up, 5:a2 up, 6:x up, 7:y up, 8:b up, 9: LStickUp, 10:LStickDown , 11: Start")]
	[SerializeField] private VoidEvent[] eventSet1;
	[SerializeField] private VoidEvent[] eventSet2;
	private VoidEvent[] currentEventSet;
	enum Sets
	{
		set1,
		set2
	}

	[SerializeField] private FloatVariable movement1;
	[SerializeField] private FloatVariable movement2;

	[SerializeField] private FloatVariable movement1y;

	public void ToggleSet()
	{
		if (chooseSet==Sets.set2)
		{
			chooseSet = Sets.set1;
		}
		else
		{
			chooseSet = Sets.set2;
		}
	}
	private void FixedUpdate()
	{
		if (chooseSet==Sets.set1)
		{
			currentEventSet = eventSet1;
		}
		else
		{
			currentEventSet = eventSet2;
		}



		movement1.Value = Input.GetAxis("HorizontalO");
		movement2.Value = Input.GetAxis("HorizontalT");
		currentEventSet[0]?.Raise();
		currentEventSet[1]?.Raise();
		movement1y.Value = Input.GetAxis("Vertical");
	}

	private void Update()
	{
		/*if (movement1y.Value>=0.3f&&movement1y.OldValue<0.3f)
		{
			movement1y.Value = 0.99f;
			currentEventSet[9]?.Raise();
			Debug.Log("firing up event");
		}
		if (movement1y.Value<=-0.3f&&movement1y.OldValue>-0.3f)
		{
			movement1y.Value = -0.99f;
			currentEventSet[10]?.Raise();
			Debug.Log("firing down event");
		}*/

		if (Input.GetKeyDown(KeyCode.Joystick1Button0)||Input.GetKeyDown(KeyCode.W))
		{
			currentEventSet[2]?.Raise();
			//a key down
		}
		if (Input.GetKeyDown(KeyCode.Joystick2Button0)||Input.GetKeyDown(KeyCode.UpArrow))
		{
			currentEventSet[3]?.Raise();
			//a key down
		}
		if (Input.GetKeyUp(KeyCode.Joystick1Button0)||Input.GetKeyUp(KeyCode.W))
		{
			currentEventSet[4]?.Raise();
			//a key up
		}
		if (Input.GetKeyUp(KeyCode.Joystick2Button0)||Input.GetKeyUp(KeyCode.UpArrow))
		{
			currentEventSet[5]?.Raise();
			//a key up
		}
		if (Input.GetKeyDown(KeyCode.JoystickButton2)||Input.GetKeyDown(KeyCode.Space))
		{
			//x key
			currentEventSet[6]?.Raise();
		}
		if (Input.GetButtonDown("CameraToggle")||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow))
		{
			//tell me WHYYYYY
			currentEventSet[7]?.Raise();
		}
		if (Input.GetKeyDown(KeyCode.JoystickButton1))
		{
			currentEventSet[8]?.Raise();
			//to b or not to b
		}

		if (Input.GetKeyDown(KeyCode.JoystickButton7))
		{
			currentEventSet[11]?.Raise();
		}
	}
}
