using UnityEngine;
using System.Collections;

public class WindowsInteraction : Interaction
{
	public string dialogue;
	// Use this for initialization
	public override void Interact ()
	{
		if (GameManager.currentItem != null)
			GameManager.PlaySpeech (GameManager.currentItem.name + " won't work here....", true);
		else
			GameManager.PlaySpeech (dialogue);
	}
}
