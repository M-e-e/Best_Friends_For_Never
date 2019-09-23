using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

[CreateAssetMenu(menuName = "Best Enemies Forever/DeBuffs/SizeDeBuff")]
public class SizeDebuff : DeBuff
{

	[SerializeField] private FloatVariable debuffSize;
	[SerializeField] private FloatVariable debuffDrag;
	public override void Apply(GameObject Target)
	{
		//Debug.Log("scaling down");
		Target.transform.localScale=new Vector3(debuffSize.Value,debuffSize.Value,Target.transform.localScale.z) ;
		Target.GetComponent<Rigidbody2D>().drag = debuffDrag.Value;
	}
}
