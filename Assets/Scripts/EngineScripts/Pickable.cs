using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using DG.Tweening;


[RequireComponent(typeof(BoxCollider2D))]
public class Pickable : MonoBehaviour
{

    // Use this for initialization

    public string itemname;
    //public int itemID;

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
		

        GetComponent<BoxCollider2D>().enabled = false;
        transform.DOScale(transform.localScale * 1.75f, .5f);
        GetComponent<SpriteRenderer>().DOFade(0, .5f);
        GameManager.inventory.AddItem(itemname);
        GameManager.slotItem = GameManager.GetInvItem(itemname);
        GameManager.GetMenu("InvButton").GetComponentInChildren<SelectedSlotScript>().UpdateSlot(GameManager.slotItem);

    }

    void Interact()
    {
		
    }
}
