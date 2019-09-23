using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	[SerializeField] private Vector2 point;
	public void SetPosition()
	{
		transform.position = point;

		FindObjectOfType<AudioManager>().Play("Teleport");
	}
}
