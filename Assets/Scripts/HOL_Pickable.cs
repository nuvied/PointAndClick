using UnityEngine;
using System.Collections;
using DG.Tweening;
using HOL;

public class HOL_Pickable : MonoBehaviour
{
	public string itemname;

	void OnMouseDown ()
	{
		transform.DOScale (transform.localScale * 1.2f, .5f);
		GetComponent<SpriteRenderer> ().DOFade (0, .5f).OnComplete (DisableSpriteRenderer);
		HOLSceneManager.i.ItemPicked (itemname);
		HOLSceneManager.i.linkedCanvas.GetComponent<HOL_UI> ().UpdateHolItemsImage ();
		HOLSceneManager.i.linkedCanvas.GetComponent<HOL_UI> ().UpdateHolItemsText ();
	}

	void DisableSpriteRenderer ()
	{
		GetComponent<SpriteRenderer> ().enabled = false;

	}
}
