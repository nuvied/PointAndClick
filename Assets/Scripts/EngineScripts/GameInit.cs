using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameInit : MonoBehaviour
{

    // Use this for initialization.
    public GameObject gameManager;

    [HideInInspector]
    public List<GameObject> _menu;

    public UIManager uiManager;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("GameManager") == null)
        {
            GameObject go = GameObject.Instantiate(gameManager);
            go.name = go.tag;
        }

        InitMenu();
    }

    void Start()
    {
		
        CameraFade.StartAlphaFade(Color.black, true, 1.5f);
    }


    void InitMenu()
    {
        GameObject.Instantiate(uiManager.cursor);
        for (int i = 0; i < uiManager.gUI.Count; i++)
        {
			
            GameObject go = GameObject.Instantiate(uiManager.gUI[i].canvas.gameObject) as GameObject;
            go.name = uiManager.gUI[i].name;
            _menu.Add(go);
            GameManager.menuObject = _menu;
            if (!uiManager.gUI[i].enableOnStart)
                go.GetComponent<Canvas>().enabled = false;
		
        }
        GameManager.GetMenu("Speech").GetComponent<Canvas>().enabled = false;
        //GameManager.runtimeInventory = GameManager.dataInv;
        Application.targetFrameRate = 40;
    }
    // Update is called once per frame
    void Update()
    {
	
    }
}
