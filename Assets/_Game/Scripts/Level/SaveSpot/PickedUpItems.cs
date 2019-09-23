using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Best Enemies Forever/DeBuffs/ItemHolder")]
public class PickedUpItems : ScriptableObject
{
	public List<List<GameObject>>  items;
	public List<List<GameObject>>  levers;


	public void ResetItems()
	{
		items.Clear();
	}

}
