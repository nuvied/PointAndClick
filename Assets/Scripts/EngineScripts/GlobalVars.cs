using UnityEngine;
using System.Collections;

[System.Serializable]
public class GlobalVars
{
	[SerializeField]
	private string _name;

	[SerializeField]
	private  int _id;

	public string name { get { return _name; } }

	public int id { get { return _id; } }

}

[System.Serializable]
public class AnyGlobalVars:GlobalVars
{


}

[System.Serializable]
public class BoolGlobalVars:GlobalVars
{

	public bool value;
}

[System.Serializable]
public class IntGlobalVars:GlobalVars
{

	public int value;

}

[System.Serializable]
public class FloatGlobalVars:GlobalVars
{
	public float value;
}

[System.Serializable]
public class StringVars:GlobalVars
{
	
}