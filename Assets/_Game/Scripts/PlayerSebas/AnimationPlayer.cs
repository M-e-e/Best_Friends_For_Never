using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class AnimationPlayer : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;
	private Animator _animator;
	private SpriteRenderer _sprite;

	private void Start()
	{
		_rigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_sprite = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		_sprite.flipX = (Mathf.Abs(_rigidbody2D.velocity.x) > .1f) ? _rigidbody2D.velocity.x < 0 : _sprite.flipX;

		_animator.SetFloat("VelocityX", Mathf.Abs(_rigidbody2D.velocity.x));
		_animator.SetFloat("VelocityY", _rigidbody2D.velocity.y);
	}
}
