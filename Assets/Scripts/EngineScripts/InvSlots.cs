using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InvSlots : MonoBehaviour
{
	//Image[] slotimage;
	GameObject[] slots;

	int offset = 0;

	public void UpdateInventory ()
	{
		//GameManager.inventory.AddItem (-1);
		// this section disable slots images at run time

		slots = GameObject.FindGameObjectsWithTag ("Slot");

		foreach (GameObject img in slots)
		{
			img.GetComponent<Image> ().enabled = false;
		}


//		if (slots.Length < GameManager.runtimeInventory.Count)
//			length = slots.Length;
//		else
//			length = GameManager.runtimeInventory.Count;
		// this section enable inventory icons from runtime inv

		for (int i = 0; i < GameManager.runtimeInventory.Count; i++)
		{
			
			if (offset + i < 0 || offset + i > slots.Length - 1)
				continue;
			
			transform.GetChild (i + offset).GetComponent<Image> ().sprite = GameManager.runtimeInventory [i].icon;
			transform.GetChild (i + offset).GetComponent<Image> ().enabled = true;
			transform.GetChild (i + offset).GetComponent<SlotScript> ().item = GameManager.runtimeInventory [i];
		}


		//print (GameManager.runtimeInventory.Count);
	}

	// Use this for initialization
	void Start ()
	{
		//transform.parent.GetComponent<Canvas> ().worldCamera = Camera.main;
		UpdateInventory ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	

	}


	public void ShiftLeft ()
	{
		if (GameManager.runtimeInventory [GameManager.runtimeInventory.Count - 1].ID == transform.GetChild (slots.Length - 1).GetComponent<SlotScript> ().item.ID ||
		    GameManager.runtimeInventory.Count < slots.Length)
			return;
		offset--;
		UpdateInventory ();

		
	}

	public void ShiftRight ()
	{
		if (offset < 0)
		{
			offset++;
			UpdateInventory ();
		}
		
	}

	public void HideInv (bool fade = true)
	{
		
	}

	public void ShowInv (bool fade = true)
	{
		
	}
}
