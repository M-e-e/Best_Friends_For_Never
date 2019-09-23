using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class SavePoint : MonoBehaviour
{
	public bool[] hasBeenActivated;
	public int numActive=-1;
	[SerializeField] private SavedActions transfer;
	[SerializeField] private PickedUpItems items;
	[SerializeField] private PickedUpItems PotionsThatWillDisappear;
	[SerializeField] private Transform[] spawnPlayer1;
	[SerializeField] private Transform[] spawnPlayer2;
	[SerializeField] private Vector3 currentSpawnPlayer1;
	[SerializeField] private Vector3 currentSpawnPlayer2;
	[SerializeField] private StringConstant playerTag;



	public void Trigger(Collider2D other, int triggerNum)
	{
		if (triggerNum>numActive)
		{
			numActive = triggerNum;
			PotionsThatWillDisappear.items[0].Clear();
			Debug.Log("clearing levers");
			PotionsThatWillDisappear.levers[0].Clear();
			Debug.Log(PotionsThatWillDisappear.levers[0].Count);
		}
		//Debug.Log(numActive +1+ " checkpoints are active");
		hasBeenActivated[numActive] = true;
		//Debug.Log(PotionsThatWillDisappear.items.Count+ " sets of potions exist");

		//Destroy(this.GetComponents<BoxCollider2D>()[0]);
		//transfer.LoadScene();
	}

	private void Start()
	{
		InitializeSpawnPoints();
		hasBeenActivated = new bool[GetComponentsInChildren<BoxCollider2D>().Length];
		//items.items.Clear();
		items.items=new List<List<GameObject>>();
		items.levers=new List<List<GameObject>>();
		foreach (var VARIABLE in hasBeenActivated)
		{
			items.items.Add(new List<GameObject>());
			items.levers.Add(new List<GameObject>());
		}
		items.items.Add(new List<GameObject>());
		items.levers.Add(new List<GameObject>());

		//PotionsThatWillDisappear.items.Clear();
		PotionsThatWillDisappear.items=new List<List<GameObject>>();
		PotionsThatWillDisappear.items.Add(new List<GameObject>());
		PotionsThatWillDisappear.levers=new List<List<GameObject>>();
		PotionsThatWillDisappear.levers.Add(new List<GameObject>());

		GameObject p1 = AtomicTags.FindAllByTag(playerTag.Value)[0];
		GameObject p2 = AtomicTags.FindAllByTag(playerTag.Value)[1];
		currentSpawnPlayer1 = new Vector3( p1.transform.position.x,p1.transform.position.y,p1.transform.position.z);
		currentSpawnPlayer2 = new Vector3( p2.transform.position.x,p2.transform.position.y,p2.transform.position.z);

		//transfer.InvokeEvent();
	}

	public void RespawnPlayers()
	{
		GameObject p1 = AtomicTags.FindAllByTag(playerTag.Value)[0];
		GameObject p2 = AtomicTags.FindAllByTag(playerTag.Value)[1];

		//!!!reset all in current cp pulled levers----------------------------------------------------------------------------------


		p1.GetComponent<Player_Movement>().ResetBuffs();
		p2.GetComponent<Player_Movement>().ResetBuffs();
		items.items[numActive+1].Clear();


		transfer.InvokeEvent();//unpull all levers

		//items.levers[numActive+1].Clear(); //reset list with in current cp pulled levers
		for (int i = 0; i <= numActive; i++)
		{
			if (hasBeenActivated[i])
			{
				currentSpawnPlayer1 = spawnPlayer1[i].position;
				currentSpawnPlayer2 = spawnPlayer2[i].position;
			}
		}

		p1.transform.position = currentSpawnPlayer1;
		p2.transform.position = currentSpawnPlayer2;
	}

	private void InitializeSpawnPoints()
	{
		Debug.Log("number of Spawnpoints: "+this.GetComponentsInChildren<BoxCollider2D>().Length);
		spawnPlayer1=new Transform[this.GetComponentsInChildren<BoxCollider2D>().Length];
		spawnPlayer2=new Transform[this.GetComponentsInChildren<BoxCollider2D>().Length];
		for (int i=0;i< this.GetComponentsInChildren<BoxCollider2D>().Length;i++)
		{
			GameObject Spawn = this.GetComponentsInChildren<BoxCollider2D>()[i].gameObject;
			spawnPlayer1[i] = Spawn.GetComponentsInChildren<Transform>()[0];
			spawnPlayer2[i] = Spawn.GetComponentsInChildren<Transform>()[1];

		}

	}
}
