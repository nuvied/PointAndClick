using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class CustomActions : Interaction
{
	public float time;
	public SpriteRenderer sr;
	public RectTransform target;
	public RectTransform marker;
	// Use this for initialization

	public override void Interact ()
	{
		sr.DOFade (0, time).OnComplete (ShowMessage);
		target.DOAnchorPos (marker.anchoredPosition, time);
		target.GetComponent<Text> ().DOFade (0, time);
	}

	void ShowMessage ()
	{
		print ("Done");
	}
}
