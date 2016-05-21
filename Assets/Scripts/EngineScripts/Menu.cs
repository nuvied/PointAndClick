using UnityEngine;
using System.Collections;

[System.Serializable]
public class Menu
{
    public string name;
    public Canvas canvas;
    public string text;
    public bool enableOnStart;
    public bool isOn;
    GameObject gameobject;

	
    void OnEnable()
    {
        gameobject = canvas.gameObject;
    }

    public GameObject gameObject{ get { return gameobject; } }

}
