using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public int width, height;
    // this is a singletone persistant class
   

    static GameManager manager;
    ///////////////////////////////////////////
    /// 
    /// 
    /// 
    
    public static List<GameObject> menuObject;

    public static Inventory inventory;
    // runtime inv
    public static List<Item> runtimeInventory;
    // data inv
    public static List<Item> dataInv;
    // global vars
    public static Item currentItem, slotItem;

    public static float fadeTime = .5f;

    public static UIManager uiManger;

    public UIManager ui;

    public static float letterPause = .01f;

    //static List<char> letter;



    ////////////////////////////////	/// <summary>
    /// 



    public static GameManager i { get { return manager; } }


    void Awake()
    {
        //CameraFade.StartAlphaFade (Color.black, true, fadeTime);
        //print ("Scene start");

        Screen.SetResolution(width, height, true);
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
		
        //Callback = SceneManager.LoadScene (0);

        runtimeInventory = GetComponent<Inventory>().items;
        dataInv = GetComponent<Inventory>().dataInv.items;
        //
        //i = this;
        inventory = GetComponent<Inventory>();


        uiManger = ui;
		
        ////////////////////////
        //InitMenu ();
        /// //////////////////
        /// 



    }


    public static void PlaySpeech(string text, bool typein = false)
    {
        if (text.Length <= 0 || IsOn(GetMenu("Speech")))
            return;


        GameManager.manager.StopAllCoroutines();
        GameManager.manager.CancelInvoke();
        //letter.Clear ();
        GetMenu("Speech").GetComponentInChildren<UnityEngine.UI.Text>().text = "";
        TurnOnMenu(GetMenu("Speech"));

        //GameObject.FindGameObjectWithTag ("Dialogue").GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
        //GameObject.FindGameObjectWithTag ("Dialogue").GetComponent<Canvas> ().enabled = true;
        GetMenu("Speech").transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(0, .15f);
        if (!typein)
        {
			
            GetMenu("Speech").GetComponentInChildren<UnityEngine.UI.Text>().text = text;
        }
        else
        {
            GameManager.manager.StartCoroutine(TypeText(text));
        }
        GameManager.manager.Invoke("DisableSpeechUI", text.Length / 5f);
    }

    public void DisableSpeechUI()
    {
        GetMenu("Speech").transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(-806f, .15f);
        GameManager.manager.StopAllCoroutines();
        TurnOffMenu(GetMenu("Speech"));
    }

    public static Item GetInvItem(int ID)
    {
        for (int i = 0; i < dataInv.Count; i++)
        {
            if (dataInv[i].ID == ID)
                return dataInv[i];
        }
        return null;
    }

    public static Item GetInvItem(string name)
    {
        for (int i = 0; i < dataInv.Count; i++)
        {
            if (dataInv[i].name == name)
                return dataInv[i];
        }
        return null;
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsOn(GetMenu("Speech")))
            TurnOffMenu(GetMenu("Speech"));

        if (!Input.GetMouseButton(0))
        {
            currentItem = null;
            CursorUI.DisbleCursor();
        }
			
    }

    static IEnumerator TypeText(string message)
    {
//		foreach (char letter in message.ToCharArray()) {
//			GetMenu ("Speech").GetComponentInChildren<UnityEngine.UI.Text> ().text += letter;
        char[] letter = message.ToCharArray();

        for (int i = 0; i < message.Length; i++)
        {
            GetMenu("Speech").GetComponentInChildren<UnityEngine.UI.Text>().text += letter[i];

		


            yield return new WaitForSeconds(letterPause);
        }
		     
    }




    public static GameObject GetMenu(string name)
    {
        if (menuObject == null)
            return null;
		
        for (int i = 0; i < menuObject.Count; i++)
        {
            if (menuObject[i].name == name)
                return menuObject[i];
        }
        return null;
    }


    public static void TurnOnMenu(GameObject menu, float time = .25f)
    {
        // check here if menu is already on
        if (menu.GetComponent<Canvas>().enabled)
            return;
		
        menu.GetComponent<CanvasGroup>().alpha = 0;
        menu.GetComponent<Canvas>().enabled = true;
        GameManager.manager.StartCoroutine((FadeInMenu(menu, time)));
    }

    public static void TurnOnMenu(string menuname, float time = .25f)
    {
        // check here if menu is already on
        GameObject menu = GetMenu(menuname);

        if (menu.GetComponent<Canvas>().enabled)
            return;

        menu.GetComponent<CanvasGroup>().alpha = 0;
        menu.GetComponent<Canvas>().enabled = true;
        GameManager.manager.StartCoroutine((FadeInMenu(menu, time)));
    }

    static IEnumerator FadeInMenu(GameObject menu, float time)
    {
        float distance = Math.Abs(menu.GetComponent<CanvasGroup>().alpha - 1);
        while (menu.GetComponent<CanvasGroup>().alpha < 1f)
        {
            menu.GetComponent<CanvasGroup>().alpha += distance / (time * 40);
            yield return new WaitForEndOfFrame();

        }

    }



    public static void TurnOffMenu(GameObject menu, float time = .25f)
    {
        // check here if menu is already off

        if (!menu.GetComponent<Canvas>().enabled)
            return;

        menu.GetComponent<CanvasGroup>().alpha = 1;
        GameManager.manager.StartCoroutine((FadeOutMenu(menu, time)));
    }

    public static void TurnOffMenu(string menuname, float time = .25f)
    {
        // check here if menu is already off
        GameObject menu = GetMenu(menuname);
        if (!menu.GetComponent<Canvas>().enabled)
            return;

        menu.GetComponent<CanvasGroup>().alpha = 1;
        GameManager.manager.StartCoroutine((FadeOutMenu(menu, time)));
    }

    static IEnumerator FadeOutMenu(GameObject menu, float time)
    {
        float distance = Math.Abs(menu.GetComponent<CanvasGroup>().alpha - 0);
        while (menu.GetComponent<CanvasGroup>().alpha > 0f)
        {
            menu.GetComponent<CanvasGroup>().alpha -= distance / (time * 40);
            //print (distance / (time * 40));
            yield return new WaitForEndOfFrame();

        }
        menu.GetComponent<Canvas>().enabled = false;

    }

    public static bool IsOn(GameObject menu)
    {
        if (menu.GetComponent<Canvas>().enabled)
            return true;
        else
            return false;
    }

    public static void ToggleMenu(GameObject menu)
    {
        GameManager.manager.StopAllCoroutines();
        if (IsOn(menu))
            TurnOffMenu(menu);
        else
            TurnOnMenu(menu);
    }

    public static void SceneSwitch(int index)
    {
        //OnFinishFade callback = GameManager.i.LoadLevel (index);
        //callback (index);
        CameraFade.StartAlphaFade(Color.black, false, 1f);
        GameManager.manager.StartCoroutine(LoadLevel(index));
        //GameManager.i.LoadLevel (index);
    }

    public static void SceneSwitch(string name)
    {
        CameraFade.StartAlphaFade(Color.black, false, 1f);
        GameManager.manager.StartCoroutine(LoadLevel(name));
    }

    static IEnumerator LoadLevel(int idx)
    {
		

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(idx);
    }

    static IEnumerator LoadLevel(string name)
    {


        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }

    public Menu Menu(string name)
    {
        for (int i = 0; i < uiManger.gUI.Count; i++)
        {
            if (uiManger.gUI[i].name == name)
                return uiManger.gUI[i];
        }
        return null;
    }
	





}
