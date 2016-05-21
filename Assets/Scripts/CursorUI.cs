using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class CursorUI : MonoBehaviour
{
	static Image img;

	// Use this for initialization
	void Start ()
	{
		img = transform.GetChild (0).GetComponent<Image> ();
		img.enabled = false;

	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.currentItem == null)
			return;
		
		img.transform.position = Input.mousePosition;



	}

	public static void EnableCursor ()
	{
		img.sprite = GameManager.currentItem.icon;
		img.enabled = true;
	}

	public static void DisbleCursor ()
	{
		img.enabled = false;
	}



}
