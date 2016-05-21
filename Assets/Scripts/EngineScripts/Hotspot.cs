using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class Hotspot : MonoBehaviour
{
    public Interaction defaultInt, itemInt, randomInt;
    public bool discardOnUse;
    public string useableItem;

    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
		

		
    }

    public void Update()
    {
        
        if (Input.touchCount > 0)
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            return;
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (onMouseUp() || OnTouchDown())
        {
            if (GameManager.currentItem == null)
            {
                print(GameManager.currentItem);
                defaultInt.Interact();
                return;
            }
            else if (GameManager.currentItem.name == useableItem)
            {
                if (useableItem.Length == 0)
                    return;
                itemInt.Interact();
                if (discardOnUse)
                    GameManager.inventory.RemoveItem(useableItem);
                return;
            }
            else
            {
                randomInt.Interact();
                return;
            }


			
        }

    }


    public bool OnTouchDown()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPos), -Vector2.up);
            if (hit.collider == GetComponent<Collider2D>())
            {

                return true;
            }
						
        }
        return false;


    }

    public bool onMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider == GetComponent<Collider2D>())
            {
                return true;
            } 
        }
        return false;
    }


}
