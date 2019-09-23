using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.Extensions;
using UnityEngine;

public class StickToMovingObject : MonoBehaviour
{
	[SerializeField] private StringConstant player;
	private void OnCollisionEnter2D(Collision2D other)

	{
		if(other.gameObject.HasTag(player)){
			Debug.Log("applied");
				other.transform.parent = transform;
		}
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

	private void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.HasTag(player)){
			other.transform.parent = null;
		}

	}
}
