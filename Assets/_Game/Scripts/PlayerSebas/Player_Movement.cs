using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityAtoms;
using UnityAtoms.Extensions;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement : MonoBehaviour
{

	private Rigidbody2D _rb;
	private PlayerState _state;
	private bool isGrounded;
	private bool _isJumping=false;
	public FloatVariable jumpForce;
	[SerializeField] private FloatVariable jumpEnhance;
	[SerializeField] private FloatVariable jumpEnhanceTimeMax;
	[SerializeField] private FloatVariable horizontalMovement;
	[SerializeField] private StringVariable jumpAxis;
	[SerializeField] private FloatVariable coyoteJump;
	[SerializeField] private FloatVariable drag;

	[SerializeField] private FloatVariable downForce;

	public FloatVariable speed;
	private float currentSpeed;
	[SerializeField] private FloatVariable airSpeed;
	[SerializeField] private FloatVariable stumbleSmooth;
	[SerializeField] private FloatVariable size;

	private FloatVariable[] _originalFloats= new FloatVariable[11];
	private Coroutine _holdJump;

	enum PlayerState
	{
		Moving,
		Idle
	};
	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_originalFloats[0] = jumpForce;
		_originalFloats[1] = jumpEnhance;
		_originalFloats[2] = jumpEnhanceTimeMax;
		_originalFloats[3] = horizontalMovement;
		_originalFloats[4] = coyoteJump;
		_originalFloats[5] = downForce;
		_originalFloats[6] = speed;
		_originalFloats[7] = airSpeed;
		_originalFloats[8] = stumbleSmooth;
		_originalFloats[9] = size;
		_originalFloats[10] = drag;
	}

	public void ResetBuffs()
	{
		jumpForce = _originalFloats[0];
		jumpEnhance = _originalFloats[1];
		jumpEnhanceTimeMax = _originalFloats[2];
		horizontalMovement = _originalFloats[3];
		coyoteJump = _originalFloats[4];
		downForce = _originalFloats[5];
		speed = _originalFloats[6];
		airSpeed = _originalFloats[7];
		stumbleSmooth = _originalFloats[8];
		size = _originalFloats[9];
		drag = _originalFloats[10];
		//transform.GetComponent<Rigidbody2D>().drag = drag.Value;
		transform.localScale=new Vector3(1,1,1);
	}

	private void Update()
	{
		SetGrounded();
		//SetMovementState();
	}
	private void FixedUpdate()
	{
		//UpdateMovementState();
		//MovePlayer(horizontalMovement.Value);

		UpdateJump();
	}


	private void SetMovementState()
	{
		if (horizontalMovement.Value>0.4f||horizontalMovement.Value<-0.4f)
		{
			_state = PlayerState.Moving;
		}
		else
		{
			_state = PlayerState.Idle;
		}
	}
	void SetGrounded()
	{
		bool tempGrounded = false;
		RaycastHit2D[] hit= new RaycastHit2D[3];
		hit[0] = Physics2D.Raycast(transform.position+new Vector3(0.35f*this.transform.localScale.y,0,0)+new Vector3(0.03f*this.transform.localScale.y,0,0) , -Vector2.up, (0.4f*this.transform.localScale.y)+0.1f);
		hit[1] = Physics2D.Raycast(transform.position-new Vector3(0.35f*this.transform.localScale.y,0,0)+new Vector3(0.03f*this.transform.localScale.y,0,0), -Vector2.up, (0.4f*this.transform.localScale.y)+0.1f);
		hit[2] = Physics2D.Raycast(transform.position , -Vector2.up, (0.4f*this.transform.localScale.y)+0.1f);

		Debug.DrawRay(transform.position+new Vector3(0.35f*this.transform.localScale.y,0,0)+new Vector3(0.03f*this.transform.localScale.y,0,0),Vector2.down*((0.4f*this.transform.localScale.y)+0.1f), Color.red);
		Debug.DrawRay(transform.position-new Vector3(0.35f*this.transform.localScale.y,0,0)+new Vector3(0.03f*this.transform.localScale.y,0,0),Vector2.down*((0.4f*this.transform.localScale.y)+0.1f), Color.red);
		Debug.DrawRay(transform.position, Vector2.down*((0.4f*this.transform.localScale.y)+0.1f), Color.red);
		//if (!hit.collider.gameObject.CompareTag(this.gameObject.tag))
		foreach (RaycastHit2D h in hit)
		{
			if (h.collider != null)
			{
				//Debug.Log(h.collider.gameObject.name);
				if (h.collider.gameObject.HasComponent<AtomicTags>())
				{
					StringConstant myTag = this.GetComponent<AtomicTags>().Tags[0];
					if (!h.collider.gameObject.GetComponent<AtomicTags>().Tags.Contains(myTag)) ;
					{
						if (!h.collider.gameObject.HasComponent<Rigidbody2D>() ||
						    h.collider.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.01f)
						{
							tempGrounded = true;
						}
					}
				}
			}
		}


		//Debug.Log(hit.collider.gameObject.tag);
		// tempGround= Physics2D.Raycast(transform.position,Vector3.down,0.53f, LayerMask.GetMask("Ground"));

		if (tempGrounded)
		{
			currentSpeed = Mathf.Lerp(currentSpeed, speed.Value, stumbleSmooth.Value);
			_isJumping = false;
			isGrounded = true;
		}
		else
		{
			currentSpeed = Mathf.Lerp(currentSpeed, speed.Value*airSpeed.Value, stumbleSmooth.Value);
			if (_isJumping)//not grounded and not jumping-> falling
			{
				isGrounded = false;
			}
			else
			{
				StartCoroutine(GroundAfterSeconds(coyoteJump.Value));
				//coroutine: set isgrounded to true after certain amount of time
			}
		}
		/*if (Input.GetButtonDown(jumpAxis.Value))
		{
			Jump();
		}
		if (Input.GetButtonUp(jumpAxis.Value))
		{
			EndJump();
		}*/
	}

	public void Jump()
	{
		SetGrounded();
		if (isGrounded)
		{
			_holdJump =  StartCoroutine(HoldingJump(jumpEnhanceTimeMax.Value));
			_rb.velocity += new Vector2(0, jumpForce.Value );
			_isJumping = true;

			FindObjectOfType<AudioManager>().Play("PlayerJump");
		}
	}
	public void EndJump()
	{
		isGrounded = false;  //------------this disables irregular double-jump. enable by deactivating this line--------------------------------------
		if (_holdJump==null)
		{
			return;
		}
		StopCoroutine(_holdJump);
        			if (_rb.velocity.y>0 )
        			{
        				StartCoroutine(StopJump());
        			}
	}
	void UpdateJump()
	{
		if (!isGrounded )
		{
			if (_rb.velocity.y>0)
			{
				//jumpForce = upForce.Value ;
				_rb.gravityScale = 1;
			}
			else
			{
				_rb.gravityScale = downForce.Value;
				//jumpForce = downForce.Value;
			}

		}
		else
		{
			_rb.gravityScale = 1;
		}
	}
	void UpdateMovementState()
	{
		if (_state == PlayerState.Moving)
		{
			_rb.velocity = new Vector2(horizontalMovement.Value*currentSpeed,_rb.velocity.y);
		}
		else
		{
			_rb.velocity=new Vector2(0,_rb.velocity.y);
		}
	}

	public void MovePlayer()
	{
		float x = horizontalMovement.Value;
		if (x>0.4f||x<-0.4f)
		{
			_rb.velocity = new Vector2(x*currentSpeed,_rb.velocity.y);
		}
		else
		{
			_rb.velocity=new Vector2(0,_rb.velocity.y);
		}
	}

	IEnumerator HoldingJump(float time)
	{
		float t = 0;
		while (t<time)
		{
			yield return new WaitForFixedUpdate();

			t += 0.08f;
			_rb.velocity += new Vector2(0, jumpEnhance.Value);
		}
	}
	IEnumerator GroundAfterSeconds(float time)
	{
		yield return new WaitForSeconds(time);
		isGrounded = false;
	}
	IEnumerator StopJump()
	{
		while (_rb.velocity.y > 0)
		{
			yield return new WaitForFixedUpdate();
			_rb.velocity = new Vector2(_rb.velocity.x, Mathf.Lerp(_rb.velocity.y, 0, 0.1f));
		}
	}


}
