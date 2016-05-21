using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using HOL;
using System.Collections.Generic;
using DG.Tweening;

public class HOL_UI : MonoBehaviour
{
	public enum UI_Type
	{
		image,
		text
	}
	// Use this for initialization
	List<GameObject> uiItems = new List<GameObject> ();
	public UI_Type type;
	public bool isSillhoutte;

	void Awake ()
	{
		UpdateHolItemsImage ();
		UpdateHolItemsText ();

	
	}

	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void UpdateHolItemsText ()
	{
		if (type == UI_Type.image)
			return;
		int length = transform.GetChild (0).childCount;
		for (int i = 0; i < length; i++)
		{
			uiItems.Add (transform.GetChild (0).GetChild (i).gameObject);
			uiItems [i].GetComponent<Text> ().enabled = false;
		}
		for (int i = 0; i < HOLSceneManager.i.runtimeItems.Count; i++)
		{
			if (!HOLSceneManager.i.runtimeItems [i].picked)
			{
				uiItems [i].GetComponent<Text> ().text = HOLSceneManager.i.runtimeItems [i].name;
				uiItems [i].GetComponent<Text> ().enabled = true;
			}
			else
			{
				uiItems [i].GetComponent<Text> ().fontStyle = FontStyle.Italic;
				uiItems [i].GetComponent<Text> ().text = HOLSceneManager.i.runtimeItems [i].name;
				uiItems [i].GetComponent<Text> ().enabled = true;
				uiItems [i].GetComponent<Text> ().DOFade (.2f, .5f);
			}
		
		}
	}

	public void UpdateHolItemsImage ()
	{
		if (type == UI_Type.text)
			return;
		int length = transform.GetChild (0).childCount;
		for (int i = 0; i < length; i++)
		{
			uiItems.Add (transform.GetChild (0).GetChild (i).gameObject);
			uiItems [i].GetComponent<Image> ().enabled = false;
		}
		for (int i = 0; i < HOLSceneManager.i.runtimeItems.Count; i++)
		{
			if (!HOLSceneManager.i.runtimeItems [i].picked)
			{
				if (isSillhoutte)
				{
					uiItems [i].GetComponent<Image> ().color = Color.black;
					uiItems [i].GetComponent<Image> ().sprite = HOLSceneManager.i.runtimeItems [i].uIcon;
					uiItems [i].GetComponent<Image> ().enabled = true;
				} else
				{
					uiItems [i].GetComponent<Image> ().color = Color.white;
					uiItems [i].GetComponent<Image> ().sprite = HOLSceneManager.i.runtimeItems [i].uIcon;
					uiItems [i].GetComponent<Image> ().enabled = true;
				}
			}
			else
			{
				
				uiItems [i].GetComponent<Image> ().sprite = HOLSceneManager.i.runtimeItems [i].uIcon;
				uiItems [i].GetComponent<Image> ().enabled = true;
				uiItems [i].GetComponent<Image> ().DOFade (.2f, .5f);
				if (isSillhoutte)
					uiItems [i].GetComponent<Image> ().DOColor (new Color (1, 1, 1, .5f), .5f);
			}

		}
	
	}
}
