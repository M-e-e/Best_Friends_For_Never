using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

[CreateAssetMenu(menuName = "Best Enemies Forever/DeBuffs/SizeBuff")]
public class SizeBuff : DeBuff
{
	[SerializeField] private FloatVariable buffSize;
	public override void Apply(GameObject Target)
	{
		//Debug.Log("scaling up");
		Target.transform.localScale=new Vector3(buffSize.Value,buffSize.Value,Target.transform.localScale.z);
	}
}
