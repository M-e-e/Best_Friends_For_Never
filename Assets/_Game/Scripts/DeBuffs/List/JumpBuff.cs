using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

[CreateAssetMenu(menuName = "Best Enemies Forever/DeBuffs/JumpBuff")]
public class JumpBuff : DeBuff
{
	[SerializeField] private FloatVariable buffJumpForce;

	public override void Apply(GameObject Target)
	{
		Target.GetComponent<Player_Movement>().jumpForce = buffJumpForce;
	}
}
