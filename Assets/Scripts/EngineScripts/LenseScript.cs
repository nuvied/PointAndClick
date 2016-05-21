using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LenseScript : MonoBehaviour
{



	public void Examine ()
	{
		if (GameManager.currentItem.splitIDs.Length > 0)
		{
			GameManager.PlaySpeech (GameManager.currentItem.splitDiscription);
			Split (GameManager.currentItem.splitIDs, GameManager.currentItem.ID);
			GameManager.currentItem = null;

		} else
		{
			GameManager.PlaySpeech (GameManager.currentItem.discription);
		}
	}

	public void Split (int[] IDs, int targetID)
	{

		GameManager.inventory.RemoveItem (targetID);
		GameManager.inventory.AddItemsByID (IDs);


	}

}
