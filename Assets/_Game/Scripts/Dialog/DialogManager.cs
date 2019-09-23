using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;
using UnityAtoms;
using UnityAtoms.Extensions;
using TMPro;
using Random = UnityEngine.Random;

public class DialogManager : MonoBehaviour
{
	[SerializeField] private DialogObject[] Player1TouchDialog;
	[SerializeField] private DialogObject[] Player2TouchDialog;

	[SerializeField] private DialogObject[] Player1DeathDialog;
	[SerializeField] private DialogObject[] Player2DeathDialog;

	[SerializeField] private StringConstant Player1Tag;
	[SerializeField] private StringConstant Player2Tag;

	[SerializeField] private FloatVariable ActivateDialogAfter;

	[SerializeField] private GameObject TextHolder;

	[SerializeField] private TextMeshProUGUI _textMeshProUgui;

	[SerializeField] private BoolVariable IsTouching1;
	[SerializeField] private BoolVariable IsTouching2;

	private bool DeathAble = true;

	[SerializeField] private IntVariable DeathDialogStatus; //0 no Dialog, 1 PLayer, 2 Player

	private AudioSource _audio;

	private GameObject Player1;
	private GameObject Player2;

	private Animator _animator;

	private float TimeStamp = 0;

	enum PlayerTurns
	{
		Player1,
		Player2
	};

	private PlayerTurns CurrentPlayer;

	// Start is called before the first frame update
    void Start()
    {

	    DeathDialogStatus.Value = 0;

		ChangeTurn();

		Player1 = AtomicTags.FindByTag(Player1Tag.Value);
		Player2 = AtomicTags.FindByTag(Player2Tag.Value);

		_animator = GetComponentInChildren<Animator>();
		_audio = GetComponent<AudioSource>();


    }

    void ChangeTurn()
    {
	    CurrentPlayer = (Random.Range(0, 2) == 0) ? PlayerTurns.Player1 : PlayerTurns.Player2;
	    TimeStamp = 0;
    }

    // Update is called once per frame
    void Update()
    {
	    TimeStamp += Time.deltaTime;



	    if (IsTouching1.Value && IsTouching2.Value)
	    {

		    FireDialog();
	    }
    }

    public void FireDialog()
    {
	    if (TimeStamp > ActivateDialogAfter.Value)
	    {
		    Debug.Log("TouchDialog");
		    switch (CurrentPlayer)
		    {
			    case PlayerTurns.Player1:

						Dialog(Player1TouchDialog[Random.Range(0, Player1TouchDialog.Length)], "Player1Talking", "Player1Stop");
					    ChangeTurn();

				    break;

			    case PlayerTurns.Player2:

						Dialog(Player2TouchDialog[Random.Range(0, Player2TouchDialog.Length)], "Player2Talking", "Player2Stop");
					    ChangeTurn();

				    break;
		    }
	    }
    }

    void Dialog(DialogObject dialogObject, String startTrigger, String stopTrigger)
    {

		StartCoroutine(DialogCoroutine(dialogObject, startTrigger, stopTrigger));

    }

    IEnumerator DialogCoroutine(DialogObject dialogObject, String startTrigger, String stopTrigger)
    {
	    //yield return new WaitForSeconds(1);

		//start Audio
		_audio.clip = dialogObject.VoiceOver_Audio;
		_audio.Play();

	    TextHolder.SetActive(true);
	    _textMeshProUgui.text = dialogObject.VoiceOver_Text;

	    _animator.SetTrigger(startTrigger);

	    yield return new WaitForSeconds(dialogObject.VoiceOver_Audio.length + 1); //Audio Length

	    _animator.SetTrigger(stopTrigger);
	    TextHolder.SetActive(false);

	    DeathAble = true;
    }



    public void DeathDialog(int status)
    {
	    Debug.Log("DeathDialog" + status);
	    switch (status)
	    {
		    case 2:

			    Dialog(Player1DeathDialog[Random.Range(0, Player1DeathDialog.Length)], "Player1Talking", "Player1Stop");

			    break;

		    case 1:

			    Dialog(Player2DeathDialog[Random.Range(0, Player2DeathDialog.Length)], "Player2Talking", "Player2Stop");

			    break;
	    }
    }

    public void ChangeStatus(int status)
    {
	    DeathDialogStatus.Value = status;


    }

    public void DeathDialog()
    {
	    if(!DeathAble) return;

	    DeathAble = false;

	    StartCoroutine(DeathDialogCoroutine());
    }

    IEnumerator DeathDialogCoroutine()
    {
	    yield return new WaitForSeconds(.5f);

	    DeathDialog(DeathDialogStatus.Value);
    }

}
