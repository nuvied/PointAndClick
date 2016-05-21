using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[CreateAssetMenu (menuName = "Point n Click/Varibale Manager")]
public class GlobalVaribalManager : ScriptableObject
{
	public enum GameStates
	{
		hafta,
		itwar,
		sunwar

	}




	public GameStates state;
	public List<BoolGlobalVars> boolVars;
	public List<IntGlobalVars> intVars;
	public List<FloatGlobalVars> floatVars;


	// Use this for initialization
	public bool GetBool (string name)
	{
		for (int i = 0; i < boolVars.Count; i++)
		{
			if (boolVars [i].name == name)
				return boolVars [i].value;
			
		}
		return false;
	}

	public bool GetBool (int id)
	{
		for (int i = 0; i < boolVars.Count; i++)
		{
			if (boolVars [i].id == id)
				return boolVars [i].value;

		}
		return false;
	}

	public void SetBool (bool value, int id)
	{
		for (int i = 0; i < boolVars.Count; i++)
		{
			if (boolVars [i].id == id)
				boolVars [i].value = value;
		}
	}

	public void SetBool (bool value, string name)
	{
		for (int i = 0; i < boolVars.Count; i++)
		{
			if (boolVars [i].name == name)
				boolVars [i].value = value;
		}
	}

	//===========================================================
	//  ints
	//===========================================================

	public bool GetInt (string name)
	{
		for (int i = 0; i < boolVars.Count; i++)
		{
			if (boolVars [i].name == name)
				return boolVars [i].value;

		}
		return false;
	}

	public bool GetInt (int id)
	{
		for (int i = 0; i < boolVars.Count; i++)
		{
			if (intVars [i].id == id)
				return boolVars [i].value;

		}
		return false;
	}

	public void SetInt (int value, int id)
	{
		for (int i = 0; i < boolVars.Count; i++)
		{
			if (intVars [i].id == id)
				intVars [i].value = value;
		}
	}

	public void SetInt (int value, string name)
	{
		for (int i = 0; i < boolVars.Count; i++)
		{
			if (intVars [i].name == name)
				intVars [i].value = value;
		}
	}

	//=====================================================
	//floats
	//=====================================================

	public float GetFloat (string name)
	{
		for (int i = 0; i < floatVars.Count; i++)
		{
			if (floatVars [i].name == name)
				return floatVars [i].value;

		}
		return 0f;
	}

	public float GetFloat (int id)
	{
		for (int i = 0; i < floatVars.Count; i++)
		{
			if (floatVars [i].id == id)
				return floatVars [i].value;

		}
		return 0f;
	}

	public void SetFloat (float value, int id)
	{
		for (int i = 0; i < floatVars.Count; i++)
		{
			if (floatVars [i].id == id)
				floatVars [i].value = value;
		}
	}

	public void SetFloat (float value, string name)
	{
		for (int i = 0; i < floatVars.Count; i++)
		{
			if (floatVars [i].name == name)
				floatVars [i].value = value;
		}
	}
}
