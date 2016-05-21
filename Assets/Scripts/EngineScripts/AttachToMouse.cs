using UnityEngine;
using System.Collections;

public class AttachToMouse : MonoBehaviour
{

	// Use this for initialization
	public GameObject _gameObject;
	Vector3 mousePos;

	void Start ()
	{
		DrawSprite ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	
	}

	public void MouseAttached ()
	{
		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		_gameObject.SetActive (true);
		_gameObject.transform.position = Vector2.Lerp (_gameObject.transform.position, mousePos, 2f);
	}

	public void DrawSprite ()
	{
		GameObject.Instantiate (_gameObject);
	}
}
