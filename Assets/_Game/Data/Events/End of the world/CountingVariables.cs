using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

[CreateAssetMenu(menuName="A new ending")]
public class CountingVariables : ScriptableObject
{
	[SerializeField] private IntVariable p1Deaths;
	[SerializeField] private IntVariable p2Deaths;
	[SerializeField] private BoolVariable menuHasBeenLoaded;

	public void ResetCountingVariables()
	{
		p1Deaths.Value = 0;
		p2Deaths.Value = 0;
		menuHasBeenLoaded.Value = false;
	}


}
