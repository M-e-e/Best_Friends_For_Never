using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_Tile_Test_Script : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Works!");
	}
}
