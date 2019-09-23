using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.Extensions;
using UnityEngine;

public class ApplyBuff : MonoBehaviour
{
	[SerializeField] private StringConstant DeBuffTag;
	[SerializeField] private PickedUpItems pickedUpItems;
	[SerializeField] private PickedUpItems PotionsThatWillReappear;
	private Collider2D otherObj;
	private GameObject lastPickup;

	private SavePoint checkpoint;
	[SerializeField] private StringConstant checkpointTag;


	private void Start()
	{
		checkpoint = AtomicTags.FindByTag(checkpointTag.Value).GetComponent<SavePoint>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		lastPickup = other.gameObject;
		if (other.gameObject.HasTag(DeBuffTag.Value))
		{
			//Debug.Log(pickedUpItems.items.Count +" sets of objects exist. Adding "+other.gameObject+ " to set"+(checkpoint.numActive+1));
			pickedUpItems.items[checkpoint.numActive+1].Add(other.gameObject);
			//Debug.Log("Found List "+PotionsThatWillReappear.items[0]);
			PotionsThatWillReappear.items[0].Add(other.gameObject);
			//Debug.Log("Added potion "+PotionsThatWillReappear.items[0][0]);
			//otherObj = other;
		}
	    if (other.gameObject.HasTag(DeBuffTag))
	    {
			//Debug.Log(PotionsThatWillReappear.items.Count+" sets of potions exist");
		    GetComponent<ActionsToSave>().ForceTransferAction(ReactivateAllThePickups);
		    GetComponent<ActionsToSave>().TransferAction(DoAllTheBuffs);
		    DoTheBuff();
	    }
    }
	public void DoAllTheBuffs()
	{
		for (int i = 0; i < checkpoint.numActive+1; i++)
		{
			//Debug.Log("set "+i+":");
			foreach (GameObject obj in pickedUpItems.items[i])
			{
				GameObject pickup = obj;
				//Debug.Log("using " +pickup);
				Apply(pickup.GetComponent<DeBuffHolder>().Buff);
				gameObject.GetComponent<GetOtherPlayer>().OtherPlayer.GetComponent<ApplyBuff>()
					.Apply(pickup.GetComponent<DeBuffHolder>().Debuff);
				pickup.gameObject.SetActive(false);
			}
		}
	}

	public void ReactivateAllThePickups()
	{
		//Debug.Log(""+PotionsThatWillReappear.items.Count+" sets of potions exist");
		//Debug.Log("reactivating "+PotionsThatWillReappear.items[0].Count+" potions");
		foreach (GameObject obj in PotionsThatWillReappear.items[0])
		{
			obj.gameObject.SetActive(true);
		}
	}


	/*public void ActivatePickup()
	{
		GameObject pickup = PotionsThatWillReappear.items[0][pickedUpItems.items[0].Count - 1];
		pickup.SetActive(true);
	}
	public void RedoTheLastBuff()
	{
		GameObject pickup = pickedUpItems.items[0][pickedUpItems.items[0].Count - 1];
		Apply(pickup.GetComponent<DeBuffHolder>().Buff);
		gameObject.GetComponent<GetOtherPlayer>().OtherPlayer.GetComponent<ApplyBuff>()
			.Apply(pickup.GetComponent<DeBuffHolder>().Debuff);
		pickup.SetActive(false);
	}*/

	public void DoTheBuff()
	{
		//Debug.Log(otherObj.name +" "+otherObj.GetComponent<DeBuffHolder>().Buff.ToString());
		///Debug.Log("Buffing: "+pickedUpItems.items[pickedUpItems.items.Count - 1]);

		//GameObject pickup = pickedUpItems.items[0][pickedUpItems.items.Count - 1];//change this to last picked up buff?
		GameObject pickup = lastPickup;
		Apply(pickup.GetComponent<DeBuffHolder>().Buff);
		gameObject.GetComponent<GetOtherPlayer>().OtherPlayer.GetComponent<ApplyBuff>()
			.Apply(pickup.GetComponent<DeBuffHolder>().Debuff);
		pickup.SetActive(false);
	}

    public void Apply(DeBuff DB)
    {
	    //not to this.gameObject but
	    DB.Apply(gameObject);
    }
}
