using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

[CreateAssetMenu(menuName = "Best Enemies Forever/DeBuffs/JumpDeBuff")]
public class JumpDebuff : DeBuff
{
	[SerializeField] private FloatVariable debuffJumpForce;

	public override void Apply(GameObject Target)
	{
		Target.GetComponent<Player_Movement>().jumpForce = debuffJumpForce;
	}
}
