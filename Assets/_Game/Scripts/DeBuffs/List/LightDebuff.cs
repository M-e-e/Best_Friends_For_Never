using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

[CreateAssetMenu(menuName = "Best Enemies Forever/DeBuffs/LightDebuff")]
public class LightDebuff : DeBuff
{
	[SerializeField] private FloatVariable BuffModier;

	[SerializeField] private FloatVariable TimeBeforeDeathModifier;

	public override void Apply(GameObject Target)
	{
		Target.GetComponentInChildren<LightCircle>().LightRadiusModifier = BuffModier.Value;

		Target.GetComponent<PlayerTouching>().StartBlinkingIn.Value += TimeBeforeDeathModifier.Value;

		Target.GetComponent<PlayerTouching>().TimeBeforeDeath.Value += TimeBeforeDeathModifier.Value;
	}
}
