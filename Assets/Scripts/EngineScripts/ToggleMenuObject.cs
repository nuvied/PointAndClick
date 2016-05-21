using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ToggleMenuObject : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    public string menuName;
    public RectTransform menuRect;
    float posY;

    void Awake()
    {
        menuRect = GameManager.GetMenu(menuName).transform.GetChild(0).GetComponent<RectTransform>();
        transform.GetChild(0).GetComponent<Text>().text = GameManager.uiManger.GetMenuByName("InvButton").text;
        posY = menuRect.anchoredPosition.y;
        print(posY);
    }

    #region IPointerDownHandler implementation

    public void OnPointerDown(PointerEventData eventData)
    {
        //GameManager.PlaySpeech ("Working");
        // GameManager.ToggleMenu(GameManager.GetMenu(menuName));
        if (!GameManager.IsOn(GameManager.GetMenu(menuName)))
        {
            GameManager.TurnOnMenu(menuName);
            menuRect.DOAnchorPosY(0, .3f);
        }
        else
        {
            GameManager.TurnOffMenu(menuName);
            menuRect.DOAnchorPosY(-211, .3f);
        }


    }






    public void OnPointerEnter(PointerEventData eventData)
    {
//        if (GameManager.currentItem != null)
//            GameManager.TurnOnMenu(GameManager.GetMenu(menuName));
    }


    #endregion


    // Use this for initialization


}
