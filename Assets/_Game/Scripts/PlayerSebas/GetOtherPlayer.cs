using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityAtoms.Extensions;

public class GetOtherPlayer : MonoBehaviour
{
	public GameObject OtherPlayer;

	[SerializeField] private StringConstant PlayerTag;

	private AtomicTags _tags;

	private void Awake()
	{
		_tags = GetComponent<AtomicTags>();
	}

	void Start()
	{
		var Players = AtomicTags.FindAllByTag(PlayerTag.Value);

		foreach (var player in Players)
		{
			if (!player.HasTag(_tags.Tags[1]))
			{
				OtherPlayer = player;
			}
		}
	}

}
