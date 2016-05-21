using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Point n Click/UIManager")]
public class UIManager : ScriptableObject
{
	public GameObject cursor;
	public List<Menu> gUI;

	// Use this for initialization

	public Menu GetMenuByName (string name)
	{
		for (int i = 0; i < gUI.Count; i++)
		{
			if (gUI [i].name == name)
			{
				return gUI [i];
			}
		}
		return null;
	}

}
