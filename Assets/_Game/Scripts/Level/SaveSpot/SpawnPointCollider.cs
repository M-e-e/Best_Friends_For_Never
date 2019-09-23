using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointCollider : MonoBehaviour
{
	[SerializeField] private Sprite activated;
	[SerializeField] private GameObject target;
	private void OnTriggerEnter2D(Collider2D other)
	{
		target.GetComponent<SpriteRenderer>().sprite = activated;
		SpawnPointCollider[] objs=  GetComponentInParent<SavePoint>().gameObject.GetComponentsInChildren<SpawnPointCollider>();
		for (int i = 0; i < objs.Length; i++)
		{
			if (objs[i] == this)
			{
				GetComponentInParent<SavePoint>().Trigger(other, i);

			}
		}
		//Destroy(GetComponent<BoxCollider2D>());

	}
}
