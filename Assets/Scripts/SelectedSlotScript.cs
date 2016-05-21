using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedSlotScript : MonoBehaviour, IBeginDragHandler,IDragHandler
{
    public Item item;
    static SelectedSlotScript i;

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        

    }

    #endregion

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        GameManager.currentItem = item;
        //CursorScript.EnableCursor ();
        CursorUI.EnableCursor();

    }

    #endregion


  












    // Use this for initialization

    //print (eventData.pointerDrag);
 




    void Start()
    {
        i = this;
        if (GameManager.slotItem == null)
        {
            GetComponent<Image>().enabled = false;
            return;
        }
        GetComponent<Image>().enabled = true;
        GetComponent<Image>().sprite = GameManager.slotItem.icon;
    }

    public void UpdateSlot(Item i)
    {
        GetComponent<Image>().enabled = true;
        GetComponent<Image>().sprite = i.icon;
        item = i;
		
    }
	
    // Update is called once per frame
    public static void EmptySlot()
    {
        i.GetComponent<Image>().enabled = false;
        i.item = null;
    }

    static SelectedSlotScript instance{ get { return i; } }
}
