using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStory_Logic : MonoBehaviour
{
	private SpriteRenderer _sprite;

	private AudioSource _audio;

	public AudioClip Explosion;
	public AudioClip Talk1;

    void Start()
    {
	    _sprite = GetComponent<SpriteRenderer>();
	    _audio = GetComponent<AudioSource>();

	    _sprite.DOFade(1, 2);

	    StartCoroutine(Story1());
    }

    IEnumerator Story1()
    {
	    yield return new WaitForSeconds(2.2f);

		_audio.Play();

		yield return new WaitForSeconds(_audio.clip.length);

		_sprite.DOFade(0, 2.2f);



		_audio.clip = Explosion;
		_audio.Play();

		yield return  new WaitForSeconds(.5f);

		Camera.main.DOShakePosition(1, .5f);
		Camera.main.DOShakeRotation(1, 2);

		yield return new WaitForSeconds(_audio.clip.length);


		_audio.clip = Talk1;
		_audio.Play();

		yield return new WaitForSeconds(_audio.clip.length);

		SceneManager.LoadScene(3);
    }
}
