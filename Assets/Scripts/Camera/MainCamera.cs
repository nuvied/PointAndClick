using UnityEngine;
using System.Collections;
using UnityEngineInternal;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
	
	// Use this for initialization
	static MainCamera i;
	public GameCamera currentCam, previousCam;

	void Awake ()
	{
		i = this;
	}

	void OnLevelWasLoaded (int lvl)
	{
		
	}

	void Start ()
	{
	
		CameraFade.StartAlphaFade (Color.black, true, .5f);
		transform.position = currentCam.position;
		transform.rotation = currentCam.rotation;
		GetComponent<Camera> ().orthographicSize = currentCam.orthographicSize;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public static GameCamera CurrentCamera{ get { return  i.currentCam; } set { i.currentCam = CurrentCamera; } }

	public static GameCamera PrevCamera{ get { return i.previousCam; } set { i.previousCam = PrevCamera; } }


}
