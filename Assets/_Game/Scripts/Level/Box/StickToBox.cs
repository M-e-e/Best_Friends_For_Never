using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.Extensions;
using UnityEngine;

public class StickToBox : MonoBehaviour
{
	[SerializeField] private StringConstant player;

	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("test0");
	}

	private void OnCollisionStay2D(Collision2D other)

	{
		Debug.Log("test1");
		if (!other.gameObject.HasTag(player)) return;
		Debug.Log("Test");
		other.gameObject.GetComponent<Rigidbody2D>().velocity += transform.GetComponent<Rigidbody2D>().velocity;
	}

/**
	private void FixedUpdate()
	{
		Debug.Log(transform.GetChild(1).gameObject);
		for(int i=0; i<10;i++)
			if (transform.GetChild(i).transform.gameObject.HasTag(player))
			{
				transform.GetChild(1).GetComponent<Rigidbody2D>().velocity =
					transform.GetComponent<Rigidbody2D>().velocity;
			}
	} **/


}
