using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

[CreateAssetMenu(menuName = "Best Enemies Forever/DeBuffs/SpeedBuff")]
public class SpeedBuff : DeBuff
{
	[SerializeField] private FloatVariable buffSpeed;

	public override void Apply(GameObject Target)
	{
		Target.GetComponent<Player_Movement>().speed= buffSpeed;
	}
}
