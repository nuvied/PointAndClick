using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{

	public Vector3 position;
	public Quaternion rotation;
	public Camera cam;
	public float orthographicSize;

	// Use this for initialization
	void Awake ()
	{
		position = transform.position;
		rotation = transform.rotation;
		cam = GetComponent<Camera> ();
		orthographicSize = cam.orthographicSize;
	}
}
