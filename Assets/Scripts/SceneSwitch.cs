using UnityEngine;
using System.Collections;
using DG.Tweening;



public class SceneSwitch : Interaction
{
	public string name;
	// Use this for initialization
	public override void Interact ()
	{

		GameManager.SceneSwitch (name);
	}


}
