using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
	public IntVariable deathCount;

	public void AddDeath(int amount = 1)
	{
		deathCount.Value += amount;
	}
}
