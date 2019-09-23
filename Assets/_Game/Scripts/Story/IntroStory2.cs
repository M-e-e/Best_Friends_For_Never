using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class IntroStory2 : MonoBehaviour
{
	public UnityEvent AfterTalk;

	private AudioSource _audio;

	public AudioClip Talk2;

	public SpriteRenderer spriteBlack;

    // Start is called before the first frame update
    void Start()
    {
	    _audio = GetComponent<AudioSource>();

	    //Camera.main.DOShakePosition(1, .3f);
	    //Camera.main.DOShakeRotation(1, 2);

	    _audio.Play();

	    spriteBlack.DOFade(0, 2);

	    StartCoroutine(Story());
    }

    IEnumerator Story()
    {
		yield return new WaitForSeconds(_audio.clip.length + .3f);

		_audio.clip = Talk2;
		_audio.Play();

		yield return new WaitForSeconds(_audio.clip.length);

		AfterTalk.Invoke();

    }


}
