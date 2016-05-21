using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraSwitch : Interaction
{
	public GameCamera cam;
	public float time;
	public bool fadeInOut;
	// Use this for initialization
	public override void Interact ()
	{
		if (fadeInOut)
		{
			time = 0;
			CameraFade.StartAlphaFade (Color.black, false, .25f);
			Invoke ("CamSwitch", .25f);
		}
		else
			CamSwitch ();

	}

	void AttatchedCamera ()
	{
		Camera.main.GetComponent<MainCamera> ().previousCam = Camera.main.GetComponent<MainCamera> ().currentCam;
		Camera.main.GetComponent<MainCamera> ().currentCam = cam;
	}

	void CamSwitch ()
	{
		Transform t = Camera.main.transform;
		t.DOMove (cam.transform.position, time);
		t.DORotate (cam.transform.rotation.eulerAngles, time);
		Camera.main.DOOrthoSize (cam.orthographicSize, time).OnComplete (AttatchedCamera);
		if (fadeInOut)
			CameraFade.StartAlphaFade (Color.black, true, .25f);
	}
}
