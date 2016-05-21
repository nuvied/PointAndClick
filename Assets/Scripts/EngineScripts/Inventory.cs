using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    // Use this for initialization
    public List<Item> items;
    public InvDatabase dataInv;



    public void AddItem(int ID)
    {

        items.Add(dataInv.GetItemByID(ID));

        GameManager.runtimeInventory = items;
        GameManager.GetMenu("Inventory").transform.GetChild(0).GetComponent<InvSlots>().UpdateInventory();
    }

    public void AddItem(string name)
    {


        items.Add(dataInv.GetItemByName(name));
        GameManager.runtimeInventory = items;
        GameManager.GetMenu("Inventory").transform.GetChild(0).GetComponent<InvSlots>().UpdateInventory();
    }

    void Awake()
    {
        //dataInv = Resources.Load<InvDatabase> ("InvDatabase");


        // use line below to copy all database items in runtime inv
        //items = dataInv.items;
    }

    public void RemoveItem(int ID)
    {
        items.Remove(dataInv.GetItemByID(ID));
        GameManager.runtimeInventory = items;
        GameManager.GetMenu("Inventory").transform.GetChild(0).GetComponent<InvSlots>().UpdateInventory();
        GameManager.slotItem = null;
        SelectedSlotScript.EmptySlot();
        
    }

    public void RemoveItem(string name)
    {
        items.Remove(dataInv.GetItemByName(name));
        GameManager.runtimeInventory = items;
        GameManager.GetMenu("Inventory").transform.GetChild(0).GetComponent<InvSlots>().UpdateInventory();
        GameManager.slotItem = null;
        SelectedSlotScript.EmptySlot();
    }

    public void ReplaceItem(int ID1, int ID2)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == ID1)
            {
                items[i] = dataInv.GetItemByID(ID2);
                GameManager.runtimeInventory = items;
                GameManager.GetMenu("Inventory").transform.GetChild(0).GetComponent<InvSlots>().UpdateInventory();
                break;
            }
        }
    }

    public void AddItemsByID(int[] IDs)
    {
        for (int i = 0; i < IDs.Length; i++)
        {
            items.Add(dataInv.GetItemByID(IDs[i]));
            GameManager.runtimeInventory = items;
            GameManager.GetMenu("Inventory").transform.GetChild(0).GetComponent<InvSlots>().UpdateInventory();
        }
    }

	

}
