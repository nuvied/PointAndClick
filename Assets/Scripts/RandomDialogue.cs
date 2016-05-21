using UnityEngine;
using System.Collections;

public class RandomDialogue : Interaction
{
	public string[] dialogues;

	void Start ()
	{
		
	}

	public override void Interact ()
	{
		GameManager.PlaySpeech (dialogues [Random.Range (0, dialogues.Length)], true);
	}
}
