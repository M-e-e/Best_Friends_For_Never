using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeBuff : ScriptableObject
{
	public abstract void Apply(GameObject Target);
}
