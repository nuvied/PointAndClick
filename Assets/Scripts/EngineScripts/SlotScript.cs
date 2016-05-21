using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using DG.Tweening;

public class SlotScript : 
MonoBehaviour, 
IPointerUpHandler,
IPointerDownHandler, 
IDragHandler, 
IBeginDragHandler,
IPointerEnterHandler
{


    public Item item;
    bool isOn;

    void Awake()
    {
		
    }



    void Update()
    {
		
    }

    #region IPointerExitHandler implementation




    ////////////////////////////////////////////////////////



    public void OnDrag(PointerEventData eventData)
    {
//		if (isOn)
//			if (!EventSystem.current.IsPointerOverGameObject () && GameManager.currentItem != null)
//			{
//				
//				GameManager.TurnOffMenu (GameManager.GetMenu ("Inventory"));
//				isOn = false;
//				return;
//			}
			

    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        //print (eventData.poi);
    }






    public void OnBeginDrag(PointerEventData eventData)
    {
        //print (eventData.pointerDrag);
        GameManager.GetMenu("InvButton").GetComponentInChildren<SelectedSlotScript>().UpdateSlot(item);
        GameManager.slotItem = item;
        GameManager.currentItem = item;
        //CursorScript.EnableCursor ();
        CursorUI.EnableCursor();
        isOn = true;
    }











    public void OnPointerDown(PointerEventData eventData)
    {
		

    }



	






    public void OnPointerUp(PointerEventData eventData)
    {
				
        if (GameManager.currentItem == null || eventData.pointerEnter == null)
        {
            GameManager.GetMenu("InvButton").GetComponentInChildren<SelectedSlotScript>().UpdateSlot(item);
            GameManager.slotItem = item;
            return;
        }

        eventData.pointerEnter.SendMessage("Examine", SendMessageOptions.DontRequireReceiver);
		

        if (eventData.pointerEnter.GetComponent<SlotScript>() == null)
            return;

        if (GameManager.currentItem.ID == eventData.pointerEnter.GetComponent<SlotScript>().item.combineID)
        {
            GameManager.PlaySpeech(GameManager.GetInvItem(GameManager.currentItem.resultID).combineDiscription);
            //GameManager.GetMenu ("Inventory").GetComponent<ExaminText> ().ShowExaminText (GameManager.GetInvItem (GameManager.currentItem.resultID).combineDiscription);
            CombineCheck(GameManager.currentItem.ID, eventData.pointerEnter.GetComponent<SlotScript>().item.ID, GameManager.currentItem.resultID);
        }


		
    }

    #endregion


    public void CombineCheck(int ID1, int ID2, int resultID)
    {
        if (ID1 >= 0 || ID2 >= 0)
            return;
        GameManager.inventory.RemoveItem(ID1);
        //GameManager.inventory.RemoveItem (ID2);
        //GameManager.inventory.AddItem (resultID);
        GameManager.inventory.ReplaceItem(ID2, resultID);
        GameManager.GetMenu("InvButton").GetComponentInChildren<SelectedSlotScript>().UpdateSlot(GameManager.GetInvItem(resultID));
        GameManager.slotItem = GameManager.GetInvItem(resultID);
    }




    // Use this for initialization



}
