using System;
using UnityEngine;


public class Marker:MonoBehaviour
{
	[HideInInspector]
	public Vector3 position, rotation, scale;

	void Awake ()
	{
		GetComponent<SpriteRenderer> ().enabled = false;
		position = transform.position;
		rotation = transform.rotation.eulerAngles;
		scale = transform.localScale;

	}
}


