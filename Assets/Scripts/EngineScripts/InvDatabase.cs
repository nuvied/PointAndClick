using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Point n Click/Inventory")]
public class InvDatabase : ScriptableObject
{
	public List<Item> items;
	// Use this for initialization


	public Item GetItemByName (string name)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (items [i].name == name)
				return items [i];
		}
		return null;
	}


	public Item GetItemByID (int ID)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (items [i].ID == ID)
				return items [i];
		}
		return null;
	}
}
