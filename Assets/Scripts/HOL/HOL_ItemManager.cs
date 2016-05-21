using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HOL
{
	[CreateAssetMenu (menuName = "HOL/CreateManager")]
	public class ItemManager : ScriptableObject
	{
		[SerializeField]
		List<HOL.Item> items;

		public List<HOL.Item> Items { get { return items; } }



	
	}
}
