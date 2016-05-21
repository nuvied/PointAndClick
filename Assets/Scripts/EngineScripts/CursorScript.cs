using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour
{
	static CursorScript i;
	// Use this for initialization
	Vector3 mousePos, cursorScale;
	public static SpriteRenderer sr;
	float cursorSize, camSize;

	void Awake ()
	{
		i = this;
	}

	void Start ()
	{
		UpdateCuros ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//MouseAttached ();

	}

	public void MouseAttached ()
	{
		 
		if (GameManager.currentItem == null)
		{
			GetComponent<SpriteRenderer> ().enabled = false;
			return;
		}

		GetComponent<SpriteRenderer> ().sprite = GameManager.currentItem.icon;
		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		gameObject.transform.position = Vector2.Lerp (gameObject.transform.position, mousePos, 1.5f);



		
	}

	public static void EnableCursor ()
	{
		//sr.enabled = true;


	}

	public void UpdateCuros ()
	{
		
		sr = GetComponent<SpriteRenderer> ();
		//GetComponent<SpriteRenderer> ().enabled = false;
		camSize = MainCamera.CurrentCamera.orthographicSize;
		cursorScale = GetComponent<RectTransform> ().localScale * camSize / 6f;
		GetComponent<RectTransform> ().localScale = cursorScale;
	}

	public static CursorScript instance{ get { return i; } }
}
