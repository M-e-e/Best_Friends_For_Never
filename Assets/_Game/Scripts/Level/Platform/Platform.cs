using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Platform : MonoBehaviour
{
	[SerializeField] private LinkedList<Transform> Points;

	[SerializeField] private float TimeToNextPlatform;

	private LinkedListNode<Transform> CurrentPoint;

	[SerializeField] private float DelayTime = 0;

	[SerializeField] private Ease EaseType;

	[SerializeField] private float Delay;

	[SerializeField] private float intervall_BacknForth;

	public enum State
	{
		Loop,
		BackAndForth,
		Static
	};

	public State currentState = State.Static;

	private void Start()
	{
		Points = new LinkedList<Transform>();

		for (int i = 1; i < transform.parent.childCount; i++)
		{
			Points.AddLast(transform.parent.GetChild(i).transform);
		}

		CurrentPoint = Points.First;

		switch (currentState)
		{
			case State.Loop:
				StartCoroutine(DelayLoop(true));
				break;

			case State.BackAndForth:
				StartCoroutine(DelayLoop(false));
				break;
		}
	}

	IEnumerator DelayLoop(bool loop)
	{
		yield return new WaitForSeconds(Delay);
		if (loop)
		{
			StartCoroutine(Loop());
		}
		else
		{
			StartCoroutine(BackAndForth());
		}

	}

	void MoveToPoint(Transform Point)
    {

	    transform.DOMove(Point.position, TimeToNextPlatform).SetEase(EaseType);
    }


    public void MoveToNextPoint()
    {

	    CurrentPoint = (CurrentPoint.Next == null) ? Points.First : CurrentPoint.Next;

	    MoveToPoint(CurrentPoint.Value);
    }

    void MoveToPreviousPoint()
    {
	    CurrentPoint = (CurrentPoint.Previous == null) ? Points.Last : CurrentPoint.Previous;

		MoveToPoint(CurrentPoint.Value);
    }

    public void MoveToFirstPoint()
    {
	    if (CurrentPoint == Points.First) return;

	    StopCoroutine(MoveToFirstPointCoroutine());
	    StopCoroutine(MoveToLastPointCoroutine());

	    StartCoroutine(MoveToFirstPointCoroutine());
    }

    IEnumerator MoveToFirstPointCoroutine()
    {
	    MoveToPreviousPoint();

	    yield return new WaitForSeconds(intervall_BacknForth);

	    MoveToFirstPoint();
    }

    public void MoveToLastPoint()
    {
	    if (CurrentPoint == Points.Last) return;

	    StopCoroutine(MoveToFirstPointCoroutine());
	    StopCoroutine(MoveToLastPointCoroutine());

	    StartCoroutine(MoveToLastPointCoroutine());
    }

    IEnumerator MoveToLastPointCoroutine()
    {
	    MoveToNextPoint();

	    yield return new WaitForSeconds(intervall_BacknForth);

	    MoveToLastPoint();
    }

    IEnumerator Loop()
    {
	    yield return new WaitForSeconds(DelayTime);
	    DelayTime = 0;

	    CurrentPoint = (CurrentPoint.Next == null) ? Points.First : CurrentPoint.Next;
	    MoveToPoint(CurrentPoint.Value);
	    yield return new WaitForSeconds(intervall_BacknForth);
	    StartCoroutine(Loop());
    }

    IEnumerator BackAndForth()
    {
	    yield return new WaitForSeconds(DelayTime);
	    DelayTime = 0;

		MoveToLastPoint();

		yield return new WaitForSeconds(intervall_BacknForth);

		MoveToFirstPoint();

		yield return new WaitForSeconds(intervall_BacknForth);

		StartCoroutine(BackAndForth());
    }

}
