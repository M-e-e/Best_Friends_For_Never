using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class CameraFollowPlayers : MonoBehaviour
{


	[SerializeField] private FloatVariable CurrentPlayerDistance;

	[SerializeField] private StringConstant PlayerTag;

	private GameObject[] Players;
	private Vector3 StartPosition;
	private float CameraSize;
	[SerializeField] private bool BigView = false;

	private void Start()
	{
		StartPosition = transform.position;
		CameraSize = Camera.main.orthographicSize;

		//find players
		Players = AtomicTags.FindAllByTag(PlayerTag.Value);
	}

	private void Update()
	{
		//Input
		/*if (Input.GetButtonDown("CameraToggle"))
		{
			ChangeView();
		}*/

		if (!BigView)
		{
			//Follow Players
			//Vector2 PlayersMidpoint = (Players[0].transform.position - Players[1].transform.position) + Players[1].transform.position / 2;
			Vector3 PlayersMidpoint = new Vector3((Players[0].transform.position.x + Players[1].transform.position.x) / 2, (Players[0].transform.position.y + Players[1].transform.position.y) / 2, StartPosition.z);

			Debug.DrawRay(transform.position, PlayersMidpoint, Color.red);
//			Debug.Log(PlayersMidpoint);

			transform.position = Vector3.Lerp(transform.position, PlayersMidpoint, .8f * Time.deltaTime);


			//Camera Size
			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, CurrentPlayerDistance.Value * 2f, .8f * Time.deltaTime);
			Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 3, CameraSize);
		}
		else
		{
			Vector3 CamPosition = transform.position;
			transform.position = Vector3.Slerp(transform.position, StartPosition, .4f * Time.deltaTime);
			transform.position = new Vector3(transform.position.x, transform.position.y, StartPosition.z);

			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, CameraSize, .1f);
		}
	}

	public void ChangeView()
	{
		Debug.Log("event received");
		if (BigView)
		{
			BigView = false;
		}
		else
		{
			BigView = true;
		}
	}
}
